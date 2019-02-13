import numpy as np
import networkx as nx
import skfuzzy as fuzzy
from skfuzzy import control as contrl
import RPi.GPIO as GPIO
import time
import math

GPIO.setmode(GPIO.BCM)

enable_A = 4
controlA_1 = 17
controlA_2 = 18
enable_B = 24
controlB_1 = 23
controlB_2 = 22

trig = 16
echo = 19

servo = 21

GPIO.setup(enable_A, GPIO.OUT)
GPIO.setup(controlA_1, GPIO.OUT)
GPIO.setup(controlA_2, GPIO.OUT)
GPIO.setup(enable_B, GPIO.OUT)
GPIO.setup(controlB_1, GPIO.OUT)
GPIO.setup(controlB_2, GPIO.OUT)

GPIO.setup(trig, GPIO.OUT , initial = 0)
GPIO.setup(echo, GPIO.IN)

GPIO.setup(servo, GPIO.OUT)

pwmEngine1 = GPIO.PWM(enable_A, 500)
pwmEngine1.start(0)

pwmEngine2 = GPIO.PWM(enable_B, 500)
pwmEngine2.start(0)

pwmServo = GPIO.PWM(servo, 50)
pwmServo.start(7)

distanse = contrl.Antecedent(np.arange(0, 501, 1),  'distanse')
duty = contrl.Consequent(np.arange(0, 101, 1), 'power')

distanse['stop1'] = fuzzy.trimf(distanse.universe, [0, 0, 10])
distanse['stop2'] = fuzzy.trimf(distanse.universe, [0, 10, 15])
distanse['stop3'] = fuzzy.trimf(distanse.universe, [10, 15, 20])
distanse['time_to_stop1'] = fuzzy.trimf(distanse.universe, [15, 20, 25])
distanse['time_to_stop2'] = fuzzy.trimf(distanse.universe, [20, 25, 30])
distanse['medium_distance'] = fuzzy.trimf(distanse.universe, [30, 40, 60])
distanse['enoght_far_away'] = fuzzy.trimf(distanse.universe, [40, 60, 90])
distanse['far_away'] = fuzzy.trimf(distanse.universe, [90, 200, 300])
distanse['very_far_away'] = fuzzy.trimf(distanse.universe, [200, 500, 500])

duty['stop'] = fuzzy.trimf(duty.universe, [0, 0, 0])
duty['low1'] = fuzzy.trimf(duty.universe, [40, 40, 45])
duty['low2'] = fuzzy.trimf(duty.universe, [40, 45, 50])
duty['medium1'] = fuzzy.trimf(duty.universe, [45, 50, 65])
duty['medium2'] = fuzzy.trimf(duty.universe, [50, 65, 90])
duty['high'] = fuzzy.trimf(duty.universe, [65, 90, 100])
duty['highest'] = fuzzy.trimf(duty.universe, [90, 100, 100])

#RULES
rule0 = contrl.Rule(distanse['stop1'] | distanse['stop2'] | distanse['stop3'], duty['stop'])
rule1 = contrl.Rule(distanse['time_to_stop1'], duty['low1'])
rule2 = contrl.Rule(distanse['time_to_stop2'], duty['low2'])
rule3 = contrl.Rule(distanse['medium_distance'], duty['medium1'])
rule4 = contrl.Rule(distanse['enoght_far_away'], duty['medium2'])
rule5 = contrl.Rule(distanse['far_away'], duty['high'])
rule6 = contrl.Rule(distanse['very_far_away'], duty['highest'])

duty_contrl = contrl.ControlSystem([rule0, rule1, rule2, rule3, rule4, rule5, rule6])
dutying = contrl.ControlSystemSimulation(duty_contrl)

counter = 1

def forward(duty):
        GPIO.output(controlA_1, True)
        GPIO.output(controlA_2, False)
        GPIO.output(controlB_1, True)
        GPIO.output(controlB_2, False)

        global counter

        if counter % 2 == 0:
            pwmEngine1.ChangeDutyCycle(duty)
            pwmEngine2.ChangeDutyCycle(duty)
        else:
            pwmEngine2.ChangeDutyCycle(duty)
            pwmEngine1.ChangeDutyCycle(duty)

def sstop():
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, False)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, False)

        pwmEngine1.ChangeDutyCycle(0)
        pwmEngine2.ChangeDutyCycle(0)

def right():
        GPIO.output(controlA_1, True)
        GPIO.output(controlA_2, False)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, True)

        pwmEngine1.ChangeDutyCycle(60)
        pwmEngine2.ChangeDutyCycle(60)

def left():
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, True)

        GPIO.output(controlB_1, True)
        GPIO.output(controlB_2, False)

        pwmEngine1.ChangeDutyCycle(60)
        pwmEngine2.ChangeDutyCycle(60)

def reverse(duty):
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, True)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, True)

        pwmEngine1.ChangeDutyCycle(duty)
        pwmEngine2.ChangeDutyCycle(duty)

def ultraSonic():
    start = 0
    stop = 0

    time.sleep(0.1);

    GPIO.output(trig, True)
    time.sleep(0.00001)
    GPIO.output(trig, False)

    while GPIO.input(echo) == 0:
        pass
        start = time.time()
    
    while GPIO.input(echo) == 1:
        pass
        stop = time.time()
    
    _dstc = (stop - start) * 17000

    if _dstc < 0:
        _dstc = 18
    return _dstc

def turnAngle(_y, _x):
    beta = math.atan2(_y,_x)
    if beta == 0:
           return 0
    alpha = (math.pi / 2) - beta
    turnTime = (alpha * 1.998)/(2 * math.pi) + 0.094
    return turnTime

def drivingAlongObstacel():
    global duty
    global totalTravelDistance
    global turnX, turnY, currentAngle
    global xGoal, yGoal

    currentTravelDistance = 0
    startTime = 0
    stop = 0

    start = time.time()
    while stop - start <= 1:
        speed = 25 * duty / 100
        #speed = (29 + (duty / 10)) * duty / 100
        totalTravelDistance += ((stop - startTime) * speed)
        currentTravelDistance += ((stop - startTime) * speed)
        
        startTime = time.time()
        print("\n")
        #print("turnX = " + str(turnX) + ":   turnY = " + str(turnY))

        print ("Speed: " + str(speed) + "sm/s")
        print ("Traveled Distance: " + str(totalTravelDistance) + "sm")
        #print ("Curent Distance " + str(currentTravelDistance) + "sm")

        #if currentAngle > 0 and currentAngle < math.pi/2
        currentX = turnX + currentTravelDistance * math.cos(currentAngle)
        currentY = turnY + currentTravelDistance * math.sin(currentAngle)

        print("X = " + str(currentX) + ":Y = " + str(currentY))
        #print("Curent Angle = " + str(math.degrees(currentAngle)))

        #time.sleep(0.01)
        dstc = ultraSonic()
        
        print ("Distance forward: " + str(dstc) + "sm")

        dutying.input['distanse'] = dstc
        dutying.compute()
        duty = math.floor(dutying.output['power'])

        forward(duty)

        print ("PWM: " + str(duty) + "%")
        stop = time.time()
    
    sstop()

    turnX = currentX
    turnY = currentY
    #print("turnX = " + str(turnX) + ":   turnY = " + str(turnY))

    currentAngle = math.atan2((yGoal - turnY), (xGoal - turnX))
    #print("Curent Angle = " + str(math.degrees(currentAngle)))

    turnTime = (math.fabs(currentAngle) * 1.998)/(2 * math.pi) + 0.094
    print("Angle Time " + str(sleepTime) + "sec\n")

    if currentAngle < math.pi / 2:
        right()
    elif currentAngle > math.pi / 2:
        left()

    time.sleep(turnTime)
    sstop()

    currentTravelDistance = 0

def detourObstacle(dutyservo, ObstacleDistance):
    global duty
    global totalTravelDistance
    global turnX, turnY, currentAngle

    currentTravelDistance = 0
    startTime = 0
    stopTime = 0
    duty = 0

    fl = True
    while fl:
        speed = 25 * duty / 100
        #speed = (29 + (duty / 10)) * duty / 100
        totalTravelDistance += ((stopTime - startTime) * speed)
        currentTravelDistance += ((stopTime - startTime) * speed)

        startTime = time.time()

        print("\n")
        #print("turnX = " + str(turnX) + ":   turnY = " + str(turnY))

        print ("Speed: " + str(speed) + "sm/s")
        print ("Traveled Distance: " + str(totalTravelDistance) + "sm")
        #print ("Curent Distance " + str(currentTravelDistance) + "sm")

        #if currentAngle > 0 and currentAngle < math.pi/2
        currentX = turnX + currentTravelDistance * math.cos(currentAngle)
        currentY = turnY + currentTravelDistance * math.sin(currentAngle)

        print("X = " + str(currentX) + ":Y = " + str(currentY))
        print("Curent Angle = " + str(math.degrees(currentAngle)))
        
        #time.sleep(0.01)
        dstc = ultraSonic()
        
        print ("Distance forward: " + str(dstc) + "sm")
        
        dutying.input['distanse'] = dstc
        dutying.compute()
        duty = math.floor(dutying.output['power'])

        forward(duty)

        print ("PWM: " + str(duty) + "%")

        pwmServo.ChangeDutyCycle(dutyservo)
        time.sleep(0.2)
        if (ObstacleDistance + 20) < ultraSonic():
            stopTime = time.time()

            totalTravelDistance += ((stopTime - startTime) * speed)
            currentTravelDistance += ((stopTime - startTime) * speed)

            #print("FALSE")
            fl = False
            time.sleep(0.4)
            sstop()

            totalTravelDistance += (0.4 * speed)
            currentTravelDistance += (0.4 * speed)

            currentX = turnX + currentTravelDistance * math.cos(currentAngle)
            currentY = turnY + currentTravelDistance * math.sin(currentAngle)

            print ("Traveled Distance: " + str(totalTravelDistance) + "sm")
            #print ("Curent Distance " + str(currentTravelDistance) + "sm")
            print("X = " + str(currentX) + ":Y = " + str(currentY))

            if dutyservo == 3:
                pwmServo.ChangeDutyCycle(7)

                right()
                time.sleep(0.51)
                sstop()

                print ("Turning Right\n")

                turnX = currentX;
                turnY = currentY;

                currentTravelDistance = 0
                currentAngle -= math.pi / 2

                drivingAlongObstacel()
            else:
                pwmServo.ChangeDutyCycle(7)

                left()
                time.sleep(0.51)
                sstop()

                print ("Turning Left\n")

                turnX = currentX;
                turnY = currentY;

                currentTravelDistance = 0
                currentAngle += math.pi / 2

                drivingAlongObstacel()
        else:
            pwmServo.ChangeDutyCycle(7)
            #time.sleep(0.1)
            stopTime = time.time()

try:
    xGoal = float(input())
    yGoal = float(input())
    
    sleepTime = turnAngle(yGoal, xGoal)
    print("Angle Time " + str(sleepTime) + "sec\n")

    right()
    time.sleep(sleepTime)
    sstop()

    currentAngle = math.atan2(yGoal, xGoal)

    duty = 0
    totalTravelDistance = 0
    currentTravelDistance = 0

    currentX = 0
    currentY = 0

    turnX = 0
    turnY = 0

    startTime = 0
    stopTime = 0

    fl = True
    while fl:
        speed = 27 * duty / 100
        #speed = (29 + (duty / 10)) * duty / 100
        totalTravelDistance += ((stopTime - startTime) * speed)
        currentTravelDistance += ((stopTime - startTime) * speed)

        startTime = time.time()

        print("\n")
        print ("Speed: " + str(speed) + "sm/s")
        print ("Traveled Distance: " + str(totalTravelDistance) + "sm")
        #print ("Curent Distance " + str(currentTravelDistance) + "sm")

        #if currentAngle > 0 and currentAngle < math.pi/2:
        #currentX = currentTravelDistance * math.sin(currentAngle)
        #currentY = currentTravelDistance * math.cos(currentAngle)

        currentX = turnX + currentTravelDistance * math.cos(currentAngle)
        currentY = turnY + currentTravelDistance * math.sin(currentAngle)

        print("X = " + str(currentX) + ":Y = " + str(currentY)) 

        #time.sleep(0.01)
        dstc = ultraSonic()
        
        print ("Distance forward: " + str(dstc) + "sm")   
             
        dutying.input['distanse'] = dstc
        dutying.compute()
        duty = math.floor(dutying.output['power'])

        forward(duty)
        print ("PWM: " + str(duty) + "%")

        if duty == 0:
            stopTime = time.time()

            currentX = turnX + currentTravelDistance * math.sin(currentAngle)
            currentY = turnY + currentTravelDistance * math.cos(currentAngle)

            currentX = turnX + currentTravelDistance * math.cos(currentAngle)
            currentY = turnY + currentTravelDistance * math.sin(currentAngle)

            print ("Traveled Distance: " + str(totalTravelDistance) + "sm")
            #print ("Curent Distance " + str(currentTravelDistance) + "sm")
            print("X = " + str(currentX) + ":Y = " + str(currentY))

            pwmServo.ChangeDutyCycle(12.5)
            time.sleep(0.5)
            dstcLeft = ultraSonic()
            print("Left distance = " + str(dstcLeft))

            pwmServo.ChangeDutyCycle(3)
            time.sleep(1.5)
            dstcRight = ultraSonic()
            print("Right distance = " + str(dstcRight))

            pwmServo.ChangeDutyCycle(7)

            if dstcRight > dstcLeft:
                right()
                time.sleep(0.51)
                sstop()

                print ("Turning Right\n")

                turnX = currentX;
                turnY = currentY;

                currentTravelDistance = 0
                currentAngle -= math.pi /2
                detourObstacle(12.5, dstc)
            else:
                left()
                time.sleep(0.51)
                sstop()

                print ("Turning Left\n")

                turnX = currentX;
                turnY = currentY;

                currentTravelDistance = 0
                currentAngle += math.pi / 2
                detourObstacle(3, dstc)
        else:        
            if math.floor(currentX) >= xGoal and math.floor(currentY) >= yGoal:
                    fl = False
                    print ("DONE")

            stopTime = time.time()

    GPIO.cleanup()
except KeyboardInterrupt:
        GPIO.cleanup()
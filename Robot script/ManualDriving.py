import RPi.GPIO as GPIO

GPIO.setmode(GPIO.BCM)

enable_A = 4
controlA_1 = 17
controlA_2 = 18
enable_B = 24
controlB_1 = 22
controlB_2 = 23

GPIO.setup(enable_A, GPIO.OUT)
GPIO.setup(controlA_1, GPIO.OUT)
GPIO.setup(controlA_2, GPIO.OUT)
GPIO.setup(enable_B, GPIO.OUT)
GPIO.setup(controlB_1, GPIO.OUT)
GPIO.setup(controlB_2, GPIO.OUT)

pwmEngine1 = GPIO.PWM(enable_A, 500)
pwmEngine1.start(0)

pwmEngine2 = GPIO.PWM(enable_B, 500)
pwmEngine2.start(0)

def forward(_duty):
        GPIO.output(controlA_1, True)
        GPIO.output(controlA_2, False)
        GPIO.output(controlB_1, True)
        GPIO.output(controlB_2, False)

        pwmEngine1.ChangeDutyCycle(_duty)
        pwmEngine2.ChangeDutyCycle(_duty)

def sstop():
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, False)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, False)

        pwmEngine1.ChangeDutyCycle(0)
        pwmEngine2.ChangeDutyCycle(0)

def right(_duty):
        GPIO.output(controlA_1, True)
        GPIO.output(controlA_2, False)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, True)

        pwmEngine1.ChangeDutyCycle(_duty)
        pwmEngine2.ChangeDutyCycle(_duty)

def left(_duty):
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, True)

        GPIO.output(controlB_1, True)
        GPIO.output(controlB_2, False)

        pwmEngine1.ChangeDutyCycle(_duty)
        pwmEngine2.ChangeDutyCycle(_duty)

def reverse(_duty):
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, True)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, True)

        pwmEngine1.ChangeDutyCycle(_duty)
        pwmEngine2.ChangeDutyCycle(_duty)

try:
    while True:
        way = input()
        if way[o] == 's':
            sstop()
        elif way[0] == 'w':
            forward(90)
            print ("Going Forward")
        elif way[0] == 'r':
            reverse(90)
            print ("Going Back")
        elif way[0] == 'a':
            left(90)
            print("Turnning Left")
        elif way[0] == 'd':
            right(90)
            print("Turnning Right")
        elif way[0] == 'e':
            GPIO.cleanup()
except KeyboardInterrupt:
    GPIO.cleanup()
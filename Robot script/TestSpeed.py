import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)

enable_A = 4
controlA_1 = 17
controlA_2 = 18
enable_B = 24
controlB_1 = 22
controlB_2 = 23

trig = 16
echo = 19

GPIO.setup(enable_A, GPIO.OUT)
GPIO.setup(controlA_1, GPIO.OUT)
GPIO.setup(controlA_2, GPIO.OUT)
GPIO.setup(enable_B, GPIO.OUT)
GPIO.setup(controlB_1, GPIO.OUT)
GPIO.setup(controlB_2, GPIO.OUT)

GPIO.setup(trig, GPIO.OUT , initial = 0)
GPIO.setup(echo, GPIO.IN)

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
        pwmEngine2.ChangeDutyCycle(_duty - 0.1)

def sstop():
        GPIO.output(controlA_1, False)
        GPIO.output(controlA_2, False)

        GPIO.output(controlB_1, False)
        GPIO.output(controlB_2, False)

        pwmEngine1.ChangeDutyCycle(0)
        pwmEngine2.ChangeDutyCycle(0)

def ultraSonic():
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
    return _dstc

try:
    startDistance = ultraSonic()
    forward(100)
    time.sleep(1)
    sstop()
    endDistance = ultraSonic()
    print(startDistance - endDistance)
    GPIO.cleanup()
except KeyboardInterrupt:
    GPIO.cleanup()
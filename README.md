## Introduction
USB power Failure tester PC software.
Compatitable with POWERMON V3.0 hardware.
Serial Communication is used to connect the hardware.


## Mode
### Mode 1
1. Write file A and calculate MD5.
2. Power off and wait for 3 seconds.
3. Power on and check the MD5 of file A.

Repeat Step 1 to 3 1000 times.
If the MD5 matches every time, the test is passed.


### Mode 2
1. Write a file A with size of half of free space to a USB drive and check the MD5.
2. Write file B and power off during the writing process.
3. Power on again and check the MD5 of the original file A.

Repeat Step 2 and 3 1000 times. 
If it the disk can be recognized normally without any error and the MD5 of the original file remains unchanged, the test is passed.

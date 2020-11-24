# SerialInput4Win

**SerialInput4Win**  is a replacement for the old SerialKeys functionality that existed in Windows XP.

It takes input from a device hooked up to a COM port ( or a USB port that's pretending to be a COM port ), and converts that input into keystrokes which can be used to enter that data into other Windows applications. 

The keystrokes are synthesized using the Windows user32.dll SendInput function ( https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput )

## Why would anyone want to do that  ?

See http://www.randomnoun.com/wp/2013/02/03/serial-input-for-windows/

## Licensing
SerialInput4Win is licensed under the BSD 2-clause license.

## Caveats
* It doesn't implement the full SerialKeys protocol, only a subset of keys are supported (mostly just the alphanumerics ).
* It's only been tested on Windows XP and WIndows 7, not sure if it works on 10 or whatever we're up to by the time you read this.


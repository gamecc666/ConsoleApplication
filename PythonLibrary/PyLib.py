# -*- coding:UTF-8 -*-

import sys


reload(sys)

sys.setdefaultencoding('utf8')
def GetSum(a,b):
    total=a+b;
    return total;

def SayWord():
    try:
        return "hello world!";
    except Exception as err:
        return str(err);

def Multiplication(para1,para2):
  
  return para1*para2;


def TestString():
    
  return '等等我,我就来了，第一次调用Python'
import datetime 
import random

class StopWatch(object):
    def __init__(self): 
        self.__starttime = datetime.datetime.now()
        #print self.__starttime

    def elapsedTime(self):
        #print datetime.datetime.now()
        gap_ = datetime.datetime.now() -self.__starttime
        return gap_.seconds + float(gap_.microseconds)/1000000


class DoubleTest(object):
    def __init__(self,start,times):
        self.__start = start
        self.__times= times
        self.__MAX = 10000


    def timeTrial(self,func):
        i = 1
        times = 1
        while(times <=self.__times):
            list = random.sample(range(-self.__MAX, self.__MAX),self.__start * i)
            print "N:",self.__start * i
            func(list)
            i = i*2
            times = times+1



#    public class DoublingTest
#{
#public static double timeTrial(int N)
#{ // Time ThreeSum.count() for N random 6-digit ints.
#int MAX = 1000000;
#int[] a = new int[N];
#for (int i = 0; i < N; i++)
#a[i] = StdRandom.uniform(-MAX, MAX);
#Stopwatch timer = new Stopwatch();
#int cnt = ThreeSum.count(a);
#return timer.elapsedTime();
#}
#public static void main(String[] args)
#{ // Print table of running times.
#for (int N = 250; true; N += N)
#{ // Print time for problem size N.
#double time = timeTrial(N);
#StdOut.printf("%7d %5.1f\n", N, time);
#}
#}
#}


#public class DoublingRatio
#{
#public static double timeTrial(int N)
#// same as for DoublingTest (page 177)
#public static void main(String[] args)
#{
#double prev = timeTrial(125);
#for (int N = 250; true; N += N)
#{
#double time = timeTrial(N);
#StdOut.printf("%6d %7.1f ", N, time);
#StdOut.printf("%5.1f\n", time/prev);
#prev = time;
#}
#}
#}
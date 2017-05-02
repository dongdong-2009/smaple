class BinarySearch(object):
    @staticmethod 
    def Find(list,a):
        lo = 0
        li = len(list) -1
        while lo <=li:
            mid = lo + (li-lo)/2
            if(a < list[mid]):
                hi = mid - 1
            elif (a > list[mid]):
                lo = mid +1
            else:
                return mid
        return -1
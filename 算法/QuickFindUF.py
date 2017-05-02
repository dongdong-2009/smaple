class QuickFindUF(object):

    def __init__(self,N): 
        self.N = N
        self.arr = range(int(N))


    def union(self,p,q):

        if self.arr[p] > self.arr[q]:
            new_value = self.arr[q]
            old_value = self.arr[p] 
        else:
            new_value = self.arr[p]
            old_value = self.arr[q] 

        for i in range(len(self.arr)):
            if self.arr[i] == old_value:
                self.arr[i] = new_value

    def connected(self,p,q):
        return self.arr[q] == self.arr[p]
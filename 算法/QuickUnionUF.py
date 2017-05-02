class QuickUnionUF(object):

    def __init__(self,N): 
        self.N = N
        self.arr = range(int(N))
        self.__sz = [0]*int(N)

    def __root(self,i):
        while(i !=self.arr[i]):
            self.arr[i] = self.arr[self.arr[i]] # path compression
            i = self.arr[i]
        return i


    def union(self,p,q):
        i = self.__root(p)
        j = self.__root(q)
        if i ==j:
            return
        if self.__sz[i] < self.__sz[j]:
            self.arr[i] = j
            self.__sz[j] +=self.__sz[i]
        else:
            self.arr[j] = ji
            self.__sz[i] +=self.__sz[j]

    def connected(self,p,q):
        return self.__root(q) == self.__root(p)
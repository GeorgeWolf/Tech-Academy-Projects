# Python:   3.6.1
#
# Author:   George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:  The Tech Academy - Python Course
#           Python sorting Drill
#
# How to use sort()
#
# list1 = [67, 45, 2, 13, 1, 998]
# list1.sort()
# print(list1)
#
# How to use sorted()
#
# print(sorted([89, 23, 33, 45, 10, 12, 45, 45, 45]))


# Bubble sort

list1 = [67, 45, 2, 13, 1, 998]
list2 = [89, 23, 33, 45, 10, 12, 45, 45, 45]

def bubbleSort(lists):
    for i in range(len(lists)-1):
        for j in range(len(lists)-1-i):
            if lists[j] > lists[j + 1]:
                lists[j], lists[j + 1] = lists[j + 1], lists[j]
                #print(lists) # See the Bubble sort step by step
    return lists

print(bubbleSort(list1))
print(bubbleSort(list2))

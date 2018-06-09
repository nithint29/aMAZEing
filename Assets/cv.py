import numpy as np
import cv2
# import os

WIN_SIZE = 800
cap = cv2.VideoCapture(0)                         
width = int(cap.get(3))  # float
height = int(cap.get(4))

while(True):
    # Capture frame-by-cq
    ret, frame = cap.read()


    cv2.rectangle(frame, (int(width//5), 50), (int(4*width//5), height-50), (0, 255, 0), 3)
    # the red center
    cv2.rectangle(frame, (int(width//2)-15, int(height//2) ) , (int(width//2)+15, int(height//2) ), (0, 0, 255), 3 )
    # gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    # Display the resulting frame
    cv2.namedWindow('image', cv2.WINDOW_NORMAL)
    # cv2.resizeWindow('image', WIN_SIZE, WIN_SIZE)
    cv2.imshow('image', frame)
    if cv2.waitKey(50) & 0xFF == ord('q'):
        break

    roi = frame[ 53:height-53,  int(width//5 +3):int(4*width//5 -3)]
    if( cv2.waitKey(50)& 0xFF == ord('c')):
        # os.remove('/Users/kxf478/PycharmProjects/untitled/raw.png')
        # ret,thresh1 = cv2.threshold(roi,127,255,cv2.THRESH_BINARY)
        cv2.imwrite('raw.png', roi)
        print('hi')
        break

# When everything done, release the capture
cap.release()
cv2.destroyAllWindows()



kernel = np.ones((5,5),np.uint8)


img = cv2.imread('raw.png', 0)
print(img==None)
cv2.imshow('image', img)
cv2.waitKey(0)
img = cv2.fastNlMeansDenoising(img)
img = cv2.GaussianBlur(img,(5,5),0)

ret,thresh1 = cv2.threshold(img,180,255,cv2.THRESH_BINARY)

dilated = cv2.erode(thresh1, kernel, iterations=1)
#cv2.imshow('image', dilated)
#cv2.waitKey(1)


# the second to last value should be changed for different lighting conditions (good values betweern 5 and 51 )
th2 = cv2.adaptiveThreshold(img,255,cv2.ADAPTIVE_THRESH_MEAN_C,\
                            cv2.THRESH_BINARY,7,2)


th2 = cv2.medianBlur(th2,5,0)
#cv2.imshow('image', th2)
#cv2.waitKey(1)

opening = cv2.morphologyEx(th2, cv2.MORPH_OPEN, kernel)
dilated = cv2.erode(opening, kernel, iterations=1)
#cv2.imshow('image', dilated)
cv2.imwrite('maze.png', dilated)
#cv2.waitKey(1000)


#find contours and then filter some out
im2, contours, hierarchy = cv2.findContours(dilated,cv2.RETR_TREE,cv2.CHAIN_APPROX_SIMPLE)
new = cv2.cvtColor(dilated, cv2.COLOR_GRAY2BGR)
cv2.drawContours(new ,contours, -1, (0,255,0), 3)
#cv2.imshow('image', new)
#cv2.waitKey(1)

print(dilated)

d = cv2.resize(dilated, (100,100))
d = d!=255
d = np.array(d)
d = d.astype(int)
f = open('maze.txt', 'w+')
np.savetxt('maze.txt', d, fmt='%i', delimiter='')

f.close()

print(d)

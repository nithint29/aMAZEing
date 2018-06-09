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

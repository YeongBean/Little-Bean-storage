from PIL import Image
from numpy import *
import tensorflow as tf
import sys

im1=Image.open("C://Users//Bean//Documents//Python Scripts//MyCNN//logs//trainer/cat1.jpg")
im2=Image.open("C://Users//Bean//Documents//Python Scripts//MyCNN//logs//trainer/cat2.jpg")
im3=Image.open("C://Users//Bean//Documents//Python Scripts//MyCNN//logs//trainer/cat3.jpg")
im4=Image.open("C://Users//Bean//Documents//Python Scripts//MyCNN//logs//trainer/dog1.jpg")
im5=Image.open("C://Users//Bean//Documents//Python Scripts//MyCNN//logs//trainer/dog2.jpg")
im6=Image.open("C://Users//Bean//Documents//Python Scripts//MyCNN//logs//trainer/dog3.jpg")

img1 = array(im1.resize((300, 260), Image.ANTIALIAS).convert("L"))
img2 = array(im2.resize((300, 260), Image.ANTIALIAS).convert("L"))
img3 = array(im3.resize((300, 260), Image.ANTIALIAS).convert("L"))
img4 = array(im4.resize((300, 260), Image.ANTIALIAS).convert("L"))
img5 = array(im5.resize((300, 260), Image.ANTIALIAS).convert("L"))
img6 = array(im6.resize((300, 260), Image.ANTIALIAS).convert("L"))

data1 = img1.reshape([1, 78000])
data2 = img2.reshape([1, 78000])
data3 = img3.reshape([1, 78000])
data4 = img4.reshape([1, 78000])
data5 = img5.reshape([1, 78000])
data6 = img6.reshape([1, 78000])


x = tf.placeholder(tf.float32, [None, 78000])
W = tf.Variable(tf.zeros([78000, 2]))
b = tf.Variable(tf.zeros([2]))

y = tf.nn.softmax(tf.matmul(x, W) + b)

saver = tf.train.Saver()
init_op = tf.global_variables_initializer()

with tf.Session() as sess:
    sess.run(init_op)
    save_path = "C://Users//Bean//Documents//Python Scripts//MyCNN//logs//model.ckpt-120.meta"
    saver.restore(sess, save_path)
    predictions1 = sess.run(y, feed_dict={x: data1})
    predictions2 = sess.run(y, feed_dict={x: data2})
    predictions3 = sess.run(y, feed_dict={x: data3})
    predictions4 = sess.run(y, feed_dict={x: data4})
    predictions5 = sess.run(y, feed_dict={x: data5})
    predictions6 = sess.run(y, feed_dict={x: data6})
    print(predictions1[0])
    print(predictions2[0])
    print(predictions3[0])
    print(predictions4[0])
    print(predictions5[0])
    print(predictions6[0]);
    

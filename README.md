基于:https://github.com/DanPristupov/WpfExpressionBlendTheme
这是一套 简易使用的WPF 主题,在基本不破坏愿意代码的基础上即可给自己的WPF程序套上暗黑套装,看起来酷酷的
![image](https://user-images.githubusercontent.com/18480528/221506389-12b89f8e-94ee-46f4-b5ac-f39a27e48edb.png)

 
语言框架>=Net4.5
主题基础源码来自github,基本控件全覆盖,可以看demo
并引入了
日历
LoadingWindow 
Pager 
DateTimePicker
 
特点	引入简单,几部就能操作 	满足先写代码,不影响界面逻辑	卸载简单,去除即可还原	   黑!!!
 
 
1	引入方法
1:将TYControls项目加入到解决方案,然后在你的项目app.xaml 加入资源
 
2:加入TYWindow,因为window 做了loading 遮罩层,需要特殊处理
 ![image](https://user-images.githubusercontent.com/18480528/221505619-4975de04-59d4-4369-9972-cb71a4000e07.png)
![image](https://user-images.githubusercontent.com/18480528/221505648-56b2711f-9290-46df-be8a-9661437a0b9c.png)
![image](https://user-images.githubusercontent.com/18480528/221505755-bafb773b-5cda-4ded-b2aa-ab6bc4621020.png)

 
 
 
搞定
 
2	Window+Loading
在原生的window上加入了Loading
效果:
 
 
TYWindow 引入了Run 来执行异步 方便loading +线程处理
Run 里面用线程处理
 
 
 
3	Pager控件
 ![image](https://user-images.githubusercontent.com/18480528/221505785-7211dac2-3030-48a4-a6f8-794b34b0c523.png)
![image](https://user-images.githubusercontent.com/18480528/221505809-505935ad-4648-447e-a7e0-d16b2d652ee0.png)
![image](https://user-images.githubusercontent.com/18480528/221505823-5a60b824-b299-47db-b068-8d74225e41b4.png)

 
 
 
 
 
 
 
4	DateTimePicker
 
 ![image](https://user-images.githubusercontent.com/18480528/221505841-03ed92d7-1b5e-45e9-9997-8de504eaf547.png)

 


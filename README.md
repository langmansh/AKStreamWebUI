<<<<<<< HEAD
# AKStreamWebUI
###### 基于AKStream流媒体管理控制接口的前端界面。
=======
### 本项目在Gitee地址
如果发现这边没有更新，请移步至Gitee更新
https://gitee.com/sscboshi/AKStreamWebUI

### AKStreamWebUI
- 基于AKStream流媒体管理控制接口的Web管理端。
- 流媒体服务采用 ZLMediaKit：https://github.com/xia-chu/ZLMediaKit
- 接口服务采用了AKStream：https://github.com/chatop2020/AKStream
### 目前已实现功能
- 设备列表（通过AKStream服务自动添加Sip设备到数据库）；
- 设备添加、编辑、删除、激活功能；
- 设备在线视频预览；
- 流媒体服务管理（启动，重启，停止，详情，热加载配置文件）;
>>>>>>> 2561ae94fb040df4a9fd63cdaad93cedc33a03af

#### 已经实现了AKStream接口功能如下：
###### 1.设备列表（可查看通过SIP自动添加的设备列表信息）。
###### 2.设备添加、编辑、删除、激活。
###### 3.设备的在线预览。

#### 项目部署：
###### 1.新建数据库，还原Document\DatabaseScript\AKStreamWebUI.sql
###### 2.修改配置文件YiSha.Admin.Web\appsettings.json(AKStream接口地址、数据库连接)
###### 3.直接将AKStream的数据库修改成与本项目一致（也可以将AKStream的表videochannels复制进来）

### 效果图
![设备激活.png](https://i.loli.net/2021/01/19/tcxRfnP6qD74pWh.png)
![设备列表.png](https://i.loli.net/2021/01/19/Fy8fSWuNhsbU7eH.png)
![设备预览.png](https://i.loli.net/2021/01/19/1aPuwDJ3W94jOky.png)
![在线设备列表.png](https://i.loli.net/2021/01/19/RzfyqKHlp83ONtW.png)
![流媒体服务管理列表.png](https://i.loli.net/2021/01/19/g9pBetQNAWrYsId.png)

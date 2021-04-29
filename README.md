### AKStreamWebUI
- 基于AKStream流媒体管理控制接口的Web管理端。
- 流媒体服务采用 ZLMediaKit：https://github.com/xia-chu/ZLMediaKit
- 接口服务采用了AKStream：https://github.com/chatop2020/AKStream
### 目前已实现功能
- 设备列表（通过AKStream服务自动添加Sip设备到数据库）；
- 设备添加、编辑、删除、激活功能；
- 设备在线视频预览；
- 流媒体服务管理（启动，重启，停止，详情，热加载配置文件）;
- 国标录像回放列表


### 项目部署
- 新建数据库，还原Document\DatabaseScript\AKStreamWebUI.sql
- 修改配置文件YiSha.Admin.Web\appsettings.json(AKStream接口地址、数据库连接)
- 直接将AKStream的数据库连接修改成与本项目连接（也可以将AKStream的表videochannels复制到本项目数据库中）
- 注意：请使用AKStreamWeb的DEBUG版本

### 运行
- 编译AKStreamWebUI项目
- 执行 dotnet YiSha.Admin.Web.dll
- 默认帐号：admin 密码：123456

### 效果图
![设备激活.png](https://i.loli.net/2021/01/19/tcxRfnP6qD74pWh.png)
![设备列表.png](https://i.loli.net/2021/01/19/Fy8fSWuNhsbU7eH.png)
![设备预览.png](https://i.loli.net/2021/01/19/1aPuwDJ3W94jOky.png)
![在线设备列表.png](https://i.loli.net/2021/01/19/RzfyqKHlp83ONtW.png)
![流媒体服务管理列表.png](https://i.loli.net/2021/01/19/g9pBetQNAWrYsId.png)

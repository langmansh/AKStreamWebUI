# AKStreamWebUI
基于AKStream流媒体管理控制接口的前端界面

已经实现了AKStream接口功能如何：
1.设备列表（可查看通过SIP自动添加的设备列表信息）。
2.设备添加、编辑、删除、激活。
3.设备的在线预览。

项目部署：
1.新建数据库，还原Document\DatabaseScript\AKStreamWebUI.sql
2.修改配置文件YiSha.Admin.Web\appsettings.json(AKStream接口地址、数据库连接)
3.直接将AKStream的数据库修改成与本项目一致（也可以将AKStream的表videochannels复制进来）

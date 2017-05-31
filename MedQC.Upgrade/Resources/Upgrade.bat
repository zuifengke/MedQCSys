@echo off
@echo ***************************************************
@echo 正在为您安装病案质控病历系统，请稍候...
@echo 版本号：{medqc_version}
@echo 请不要手动关闭本窗口

rem 等待三秒钟
ping -n 3 127.0.0.1

@echo 正在拷贝版本文件... 
xcopy "{app_path}\Upgrade" "{app_path}" /e /q /h /r /y
if errorlevel 5 goto err
if errorlevel 4 goto err
if errorlevel 3 goto err
if errorlevel 2 goto err
if errorlevel 1 goto err

@echo 正在拷贝配置文件... 

xcopy "{app_path}\MedQCSys_Bak.xml" "{app_path}\MedQCSys.xml" /q /y


@echo 正在启动病案质控系统，请稍候...
start "电子病历系统" "{app_path}\mrqc.exe" "{app_args}"

:err
if exist "{app_path}\Upgrade" (rd "{app_path}\Upgrade" /s /q)
if exist "{app_path}\{medqc_version}.zip" (del "{app_path}\{medqc_version}.zip" /q /f)
if exist "{app_path}\MedQCSys_Bak.xml" (del "{app_path}\MedQCSys_Bak.xml" /q /f)
if exist "{app_path}\Upgrade.bat" (del "{app_path}\Upgrade.bat" /q /f)
if exist "{app_path}\AutoUpgrade.bat" (del "{app_path}\AutoUpgrade.bat" /q /f)

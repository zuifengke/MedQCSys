/*********************
* 控件初始化帮助类
* by yehui
**********************/
using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Controls;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls.DictInput;

namespace Heren.MedQC.Utilities
{
    public class InitControlData
    {
        public static bool InitCboDeptName(ref FindComboBox cboDeptName)
        {
            List<DeptInfo> lstDeptInfo = null;
            short shRet = DeptAccess.Instance.GetClinicInpDeptList(ref lstDeptInfo);             if (shRet != SystemData.ReturnValue.OK 
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                return false;
            }
            if (lstDeptInfo == null)
                return true;
            if (cboDeptName.Items.Count > 0)
                cboDeptName.Items.Clear();
            foreach (var item in lstDeptInfo)
            {
                cboDeptName.Items.Add(item);
            }
            cboDeptName.Items.Insert(0, string.Empty);
            return true;
        }
        public static bool InitcboUserList(ref FindComboBox cboUserList)
        {
            List<UserInfo> lstUserInfo = null;
            short shRet =UserAccess.Instance.GetAllUserInfos(ref lstUserInfo);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                return false;
            }
            if (lstUserInfo == null)
                return true;
            if (cboUserList.Items.Count > 0)
                cboUserList.Items.Clear();
            foreach (var item in lstUserInfo)
            {
                cboUserList.Items.Add(item);
            }
            cboUserList.Items.Insert(0, string.Empty);
            return true;
        }

    }
}

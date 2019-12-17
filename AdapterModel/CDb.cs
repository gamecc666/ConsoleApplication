namespace ConsoleApplication.AdapterModel
{
    public enum EDbType
    {
        Unknow=0,
        X=1,
        Y=2
    }
    //统一的使用者来操作X，Y公司的数据；因此此类得到目的是创建对象并指定操作那个公司的数据
    class CDb:IDbx
    {
        private IDbx myDb;

        public CDb(EDbType dbType)
        {
            if(dbType== EDbType.X)
            {
                myDb = new CDbX();
            }
            else if(dbType== EDbType.Y)
            {
                CDbY dby = new CDbY();
                myDb = new CDbYAdapter(dby);//注意这里的转换（这是关键）
            }
        }

        public void LoadData()
        {
            myDb.LoadData();
        }

        public void SaveData()
        {
            myDb.SaveData();
        }
    }
}

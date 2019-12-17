namespace ConsoleApplication.AdapterModel
{
    //通过适配器来将Y公司的数据操作接口转换成X公司的使用方法
    class CDbYAdapter:IDbx
    {
        private IDbY myDby;

        public CDbYAdapter(IDbY dby)
        {
            this.myDby = dby;
        }

        public void LoadData()
        {
            myDby.ReadData();
        }

        public void SaveData()
        {
            myDby.WriteData();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class ColumnInfo
    {
        private int _sequence;
        private string _columnname;
        private string _datatype;
        private int _columnlength;
        private int _precisionlength;
        private int _scale;
        private string _defaultvalue;
        private string _columndescription;
        private bool _isidentity;
        private bool _isprimarykey;
        private bool _isnullable;

        public ColumnInfo()
        {
        }

        public ColumnInfo(string columnname)
        {
            _columnname = columnname;
        }

        /// <summary>
        /// 字段序号
        /// </summary>
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName
        {
            get { return _columnname; }
            set { _columnname = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public string DataType
        {
            get { return _datatype; }
            set { _datatype = value; }
        }

        /// <summary>
        /// 占用字节数
        /// </summary>
        public int ColumnLength
        {
            get { return _columnlength; }
            set { _columnlength = value; }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int PrecisionLength
        {
            get { return _precisionlength; }
            set { _precisionlength = value; }
        }

        /// <summary>
        /// 小数位数
        /// </summary>
        public int Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue
        {
            get { return _defaultvalue; }
            set { _defaultvalue = value; }
        }

        /// <summary>
        /// 字段说明
        /// </summary>
        public string ColumnDescription
        {
            get { return _columndescription; }
            set { _columndescription = value; }
        }

        /// <summary>
        /// 标识.
        /// </summary>
        public bool IsIdentity
        {
            get { return _isidentity; }
            set { _isidentity = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return _isprimarykey; }
            set { _isprimarykey = value; }
        }

        /// <summary>
        /// 允许空
        /// </summary>
        public bool IsNullable
        {
            get { return _isnullable; }
            set { _isnullable = value; }
        }

        public override string ToString()
        {
            if (ColumnName == string.Empty)
                return base.ToString();
            else
                return ColumnName;
        }
    }
}

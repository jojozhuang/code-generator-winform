SELECT   
Table_Name=d.name, 
Table_Description=isnull(f.value, ' '), 
[Sequence]=a.colorder, 
Column_Name=a.name, 
IsIdentity=case   when   COLUMNPROPERTY(a.id,a.name, 'IsIdentity')=1 then '1' else '0' end, 
IsPrimaryKey=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype= 'PK '   and   name   in   ( 
SELECT   name   FROM   sysindexes   WHERE   indid   in( 
SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid 
)))   then   '1'   else   '0'   end, 
Data_Type=b.name, 
Column_Length=a.length, 
Precision_Length=COLUMNPROPERTY(a.id,a.name, 'PRECISION'), 
Scale=isnull(COLUMNPROPERTY(a.id,a.name, 'Scale'),0), 
IsNullable=case   when   a.isnullable=1   then   '1 'else   '0'   end, 
Default_Value=isnull(e.text, ' '), 
Column_Description=isnull(g.[value], ' ')
FROM   syscolumns   a 
left   join   systypes   b   on   a.xtype=b.xusertype 
inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype= 'U '   and   d.status> =0 
left   join   syscomments   e   on   a.cdefault=e.id 
left   join   sysproperties   g   on   a.id=g.id   and   a.colid=g.smallid     
left   join   sysproperties   f   on   d.id=f.id   and   f.smallid=0 
where   d.name= '#TableName#'         --如果只查询指定表,加上此条件 
order   by   a.id,a.colorder

/*SELECT
	INFORMATION_SCHEMA.COLUMNS.*,
	COL_LENGTH('#TableName#', INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME) AS COLUMN_LENGTH,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsComputed') AS IS_COMPUTED,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsIdentity') AS IS_IDENTITY,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsRowGuidCol') AS IS_ROWGUIDCOL,	
	IS_PRIMARYKEY = 
	CASE 
	    WHEN INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = pk_table.COLUMN_NAME THEN '1'
	    ELSE '0'
	  END,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'Precision') AS PRECISION_LEN,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'Scale') AS SCALE
FROM
	INFORMATION_SCHEMA.COLUMNS,
	(SELECT
	 T.TABLE_NAME,
	 COALESCE( CU.CONSTRAINT_NAME , '(no primary key)') 
	    AS PRIMARY_KEY_NAME,
	 CU.COLUMN_NAME 
	FROM INFORMATION_SCHEMA.TABLES AS T
	LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
	 ON TC.TABLE_CATALOG = T.TABLE_CATALOG
	 AND TC.TABLE_SCHEMA = T.TABLE_SCHEMA
	 AND TC.TABLE_NAME = T.TABLE_NAME
	 AND TC.CONSTRAINT_TYPE = 'PRIMARY KEY'
	LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS CU
	 ON CU.CONSTRAINT_CATALOG = TC.CONSTRAINT_CATALOG
	 AND CU.CONSTRAINT_SCHEMA = TC.CONSTRAINT_SCHEMA
	 AND CU.CONSTRAINT_NAME = TC.CONSTRAINT_NAME
	WHERE
	 T.TABLE_TYPE = 'BASE TABLE'
	 AND T.TABLE_NAME = '#TableName#') AS pk_table 
WHERE
	INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '#TableName#'
ORDER BY ORDINAL_POSITION*/


/*SELECT
	INFORMATION_SCHEMA.COLUMNS.*,
	COL_LENGTH('#TableName#', INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME) AS COLUMN_LENGTH,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsComputed') AS IS_COMPUTED,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsIdentity') AS IS_IDENTITY,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsRowGuidCol') AS IS_ROWGUIDCOL,	
	IS_PRIMARYKEY = 
	CASE 
	    WHEN INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME = pk_table.COLUMN_NAME THEN '1'
	    ELSE '0'
	  END,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'Precision') AS PRECISION_LEN,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'Scale') AS SCALE
FROM
	INFORMATION_SCHEMA.COLUMNS,(select COLUMN_NAME from INFORMATION_SCHEMA.KEY_COLUMN_USAGE a
inner join INFORMATION_SCHEMA.TABLE_CONSTRAINTS b
on a.CONSTRAINT_NAME = b.CONSTRAINT_NAME
where a.table_name = '#TableName#' and constraint_type = 'Primary key') AS pk_table
WHERE
	INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '#TableName#'
ORDER BY ORDINAL_POSITION*/

/*SELECT
	INFORMATION_SCHEMA.COLUMNS.*,
	COL_LENGTH('#TableName#', INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME) AS COLUMN_LENGTH,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsComputed') AS IS_COMPUTED,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsIdentity') AS IS_IDENTITY,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsRowGuidCol') AS IS_ROWGUIDCOL
FROM
	INFORMATION_SCHEMA.COLUMNS
WHERE
	INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '#TableName#'*/
	
/*
SELECT   
表名=case   when   a.colorder=1   then   d.name   else   ' '   end, 
表说明=case   when   a.colorder=1   then   isnull(f.value, ' ')   else   ' '   end, 
字段序号=a.colorder, 
字段名=a.name, 
标识=case   when   COLUMNPROPERTY(   a.id,a.name, 'IsIdentity ')=1   then   '√ 'else   ' '   end, 
主键=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype= 'PK '   and   name   in   ( 
SELECT   name   FROM   sysindexes   WHERE   indid   in( 
SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid 
)))   then   '√ '   else   ' '   end, 
类型=b.name, 
占用字节数=a.length, 
长度=COLUMNPROPERTY(a.id,a.name, 'PRECISION '), 
小数位数=isnull(COLUMNPROPERTY(a.id,a.name, 'Scale '),0), 
允许空=case   when   a.isnullable=1   then   '√ 'else   ' '   end, 
默认值=isnull(e.text, ' '), 
字段说明=isnull(g.[value], ' '), 
索引名称=isnull(h.索引名称, ' '), 
索引顺序=isnull(h.排序, ' ') 
FROM   syscolumns   a 
left   join   systypes   b   on   a.xtype=b.xusertype 
inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype= 'U '   and   d.status> =0 
left   join   syscomments   e   on   a.cdefault=e.id 
left   join   sysproperties   g   on   a.id=g.id   and   a.colid=g.smallid     
left   join   sysproperties   f   on   d.id=f.id   and   f.smallid=0 
left   join(--这部分是索引信息,如果要显示索引与表及字段的对应关系,可以只要此部分 
select   索引名称=a.name,c.id,d.colid 
,排序=case   indexkey_property(c.id,b.indid,b.keyno, 'isdescending ') 
when   1   then   '降序 '   when   0   then   '升序 '   end 
from   sysindexes   a 
join   sysindexkeys   b   on   a.id=b.id   and   a.indid=b.indid 
join   (--这里的作用是有多个索引时,取索引号最小的那个 
select   id,colid,indid=min(indid)   from   sysindexkeys 
group   by   id,colid)   b1   on   b.id=b1.id   and   b.colid=b1.colid   and   b.indid=b1.indid 
join   sysobjects   c   on   b.id=c.id   and   c.xtype= 'U '   and   c.status> =0 
join   syscolumns   d   on   b.id=d.id   and   b.colid=d.colid 
where   a.indid   not   in(0,255) 
)   h   on   a.id=h.id   and   a.colid=h.colid 
--where   d.name= '要查询的表 '         --如果只查询指定表,加上此条件 
order   by   a.id,a.colorder
*/
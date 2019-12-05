<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output omit-xml-declaration="yes" indent="no" method="text" encoding="UTF-8"/>
	<xsl:template match="/">
		<xsl:text>using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using Johnny.CMS.OM;
using Johnny.Library.Database;

namespace </xsl:text>
		<xsl:value-of select="entity/@namespace"/>
		<xsl:text>.DAL
{
</xsl:text>
		<xsl:apply-templates select="entity"/>
		<xsl:text>
}
</xsl:text>
	</xsl:template>
	<xsl:template match="entity">
	/// &lt;summary&gt;
	/// <xsl:value-of select="@name"/>
		<xsl:text> is a DAL calss that represents </xsl:text>
		<xsl:value-of select="@description"/>
	/// &lt;/summary&gt;
	public class DAL<xsl:value-of select="@name"/>
	{
		/// &lt;summary&gt;
        /// Method to get recoders with condition
        /// &lt;/summary&gt;    	 
        public IList&lt;<xsl:value-of select="@modelName"/>&gt; GetList()
        {
            IList&lt;<xsl:value-of select="@modelName"/>&gt; list = new List&lt;<xsl:value-of select="@modelName"/>&gt;();

            StringBuilder strSql = new StringBuilder();
            <xsl:text>strSql.Append("SELECT </xsl:text>
            <xsl:for-each select="./columns/property">
            	<xsl:text>[</xsl:text>
            	<xsl:value-of select="@name"/>
            	<xsl:text>]</xsl:text>
				<xsl:if test="position()!=last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each><xsl:text> ");
            strSql.Append(" FROM [</xsl:text>
            <xsl:value-of select="@name"/>] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    <xsl:value-of select="@modelName"/> item = new <xsl:value-of select="@modelName"/>
                    <xsl:text>(</xsl:text>
                <xsl:for-each select="./columns/property">
					<xsl:text>sdr.</xsl:text>
					<xsl:value-of select="@getMethod"/>
					<xsl:text>(</xsl:text>	
					<xsl:number value="position()-1" format="1"/>
					<xsl:text>)</xsl:text>
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>					
				</xsl:for-each>);
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// &lt;summary&gt;
        /// Method to get one recoder by primary key
        /// &lt;/summary&gt;    	 
        public <xsl:value-of select="@modelName"/> GetModel(int <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>)
        {
			//Set up a return value
            <xsl:value-of select="@modelName"/> model = null;

            StringBuilder strSql = new StringBuilder();
            <xsl:text>strSql.Append("SELECT </xsl:text>
            <xsl:for-each select="./columns/property">
				<xsl:text>[</xsl:text>
				<xsl:value-of select="@name"/>
				<xsl:text>]</xsl:text>
				<xsl:if test="position()!=last()">
					<xsl:text>, </xsl:text>
				</xsl:if>
			</xsl:for-each><xsl:text> ");
            strSql.Append(" FROM [</xsl:text>
            <xsl:value-of select="@name"/>] ");
            strSql.Append(" WHERE [<xsl:for-each select="./primaryKey/column">
            	<xsl:value-of select="@columnName"/>
          	</xsl:for-each>]=" + <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new <xsl:value-of select="@modelName"/>
                <xsl:text>(</xsl:text>
                <xsl:for-each select="./columns/property">
					<xsl:text>sdr.</xsl:text>
					<xsl:value-of select="@getMethod"/>
					<xsl:text>(</xsl:text>	
					<xsl:number value="position()-1" format="1"/>
					<xsl:text>)</xsl:text>
					<xsl:if test="position()!=last()">
						<xsl:text>, </xsl:text>
					</xsl:if>					
				</xsl:for-each>);
				else
                    model = new <xsl:value-of select="@modelName"/>();                
            }
            return model;
        }

        /// &lt;summary&gt;
        /// Add one record
        /// &lt;/summary&gt;
        public int Add(<xsl:value-of select="@modelName"/> model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [<xsl:value-of select="@name"/>]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [<xsl:value-of select="@name"/>](");
            strSql.Append("<xsl:for-each select="./columns/property">
            				<xsl:if test="@identity!='True'">
								<xsl:text>[</xsl:text>
								<xsl:value-of select="@name"/>
								<xsl:text>]</xsl:text>	
								<xsl:if test="position()!=last()">
									<xsl:text>,</xsl:text>
								</xsl:if>
							</xsl:if>
							</xsl:for-each>");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            <xsl:for-each select="./columns/property">
            	<xsl:if test="@identity!='True'">
		            <xsl:text>strSql.Append("</xsl:text>
		            <xsl:if test="@pattern='Yes'">
		            	<xsl:text>'</xsl:text>
		            </xsl:if>
					<xsl:text>" + </xsl:text>
					<xsl:if test="@pattern='Boolean'">
		            	<xsl:text>(</xsl:text>
		            </xsl:if>
		            <xsl:text>model.</xsl:text>
					<xsl:value-of select="@name"/>
					<xsl:if test="@pattern='Boolean'">
		            	<xsl:text> == true ? "1" : "0")</xsl:text>
		            </xsl:if>
					<xsl:text> + "</xsl:text>
					<xsl:if test="@pattern='Yes'">
		            	<xsl:text>'</xsl:text>
		            </xsl:if>
		            <xsl:if test="position()!=last()">
						<xsl:text>,</xsl:text>
					</xsl:if>
					<xsl:text>");
			</xsl:text>
				</xsl:if>
			</xsl:for-each>strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        
        /// &lt;summary&gt;
        /// Update one record
        /// &lt;/summary&gt;
        public void Update(<xsl:value-of select="@modelName"/> model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [<xsl:value-of select="@name"/>] SET ");
            <xsl:for-each select="./columns/property">
            	<xsl:if test="@identity!='True'">
		            <xsl:text>strSql.Append("[</xsl:text>
		            <xsl:value-of select="@name"/>
					<xsl:text>]=</xsl:text>
					<xsl:if test="@pattern='Yes'">
		            	<xsl:text>'</xsl:text>
		            </xsl:if>
		            <xsl:text>" + </xsl:text>
					<xsl:if test="@pattern='Boolean'">
		            	<xsl:text>(</xsl:text>
		            </xsl:if>
		            <xsl:text>model.</xsl:text>		            
					<xsl:value-of select="@name"/>
					<xsl:if test="@pattern='Boolean'">
		            	<xsl:text> == true ? "1" : "0")</xsl:text>
		            </xsl:if>
					<xsl:text> + "</xsl:text>
					<xsl:if test="@pattern='Yes'">
		            	<xsl:text>'</xsl:text>
		            </xsl:if>
		            <xsl:if test="position()!=last()">
						<xsl:text>,</xsl:text>
					</xsl:if>
					<xsl:text>");
			</xsl:text>
				</xsl:if>
			</xsl:for-each>strSql.Append(" WHERE [<xsl:for-each select="./primaryKey/column">
            	<xsl:value-of select="@columnName"/>]=" + model.<xsl:value-of select="@columnName"/> + ""</xsl:for-each>);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// &lt;summary&gt;
		/// Delete record by primary key
		/// &lt;/summary&gt;
        public void Delete(int <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [<xsl:value-of select="@name"/>] WHERE [<xsl:for-each select="./primaryKey/column">
            	<xsl:value-of select="@columnName"/>
            </xsl:for-each>]=" + <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// &lt;summary&gt;
		/// Check exist by primary key
		/// &lt;/summary&gt;
        public bool IsExist(int <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [<xsl:value-of select="@name"/>] WHERE [<xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>]=" + <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}</xsl:template>
</xsl:stylesheet>

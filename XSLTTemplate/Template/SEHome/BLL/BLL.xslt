<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output omit-xml-declaration="yes" indent="no" method="text" encoding="UTF-8"/>
	<xsl:template match="/">
		<xsl:text>using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace </xsl:text>
		<xsl:value-of select="entity/@namespace"/>
		<xsl:text>.BLL
{
</xsl:text>
		<xsl:apply-templates select="entity"/>
}
	</xsl:template>
	<xsl:template match="entity">
	/// &lt;summary&gt;
	/// A business component to manage <xsl:value-of select="@name"/>
	/// &lt;/summary&gt;
	public class BLL<xsl:value-of select="@name"/>
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL<xsl:value-of select="@name"/> dal = new DAL<xsl:value-of select="@name"/>();
	    
		/// &lt;summary&gt;
        /// Method to get recoders with condition
        /// &lt;/summary&gt;    	 
        public IList&lt;<xsl:value-of select="@modelName"/>&gt; GetList()
        {
            return dal.GetList();
        }
        
		/// &lt;summary&gt;
        /// Method to get one recoder by primary key
        /// &lt;/summary&gt;    	 
        public <xsl:value-of select="@modelName"/> GetModel(int <xsl:for-each select="./primaryKey/column">
        <xsl:value-of select="@columnName"/></xsl:for-each>)
        {
			return dal.GetModel(<xsl:for-each select="./primaryKey/column">
			<xsl:value-of select="@columnName"/></xsl:for-each>);
        }

        /// &lt;summary&gt;
        /// Add one record
        /// &lt;/summary&gt;
        public int Add(<xsl:value-of select="@modelName"/> model)
        {
            return dal.Add(model);
        }
        
        /// &lt;summary&gt;
        /// Update one record
        /// &lt;/summary&gt;
        public void Update(<xsl:value-of select="@modelName"/> model)
        {
        	dal.Update(model);
        }
        
        /// &lt;summary&gt;
		/// Delete record by primary key
		/// &lt;/summary&gt;
        public void Delete(int <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>)
        {
            dal.Delete(<xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>);
        }
        
        /// &lt;summary&gt;
		/// Check exist by primary key
		/// &lt;/summary&gt;
        public bool IsExist(int <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>)
        {
            return dal.IsExist(<xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>);
        }
	}</xsl:template>
</xsl:stylesheet>

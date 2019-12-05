﻿<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output omit-xml-declaration="yes" indent="no" method="text" encoding="UTF-8"/>
	<xsl:template match="/">
		<xsl:text>/************************************************************************
This class is generated by ZrXSCodeGen
ZrXSCodeGen </xsl:text>
		<xsl:value-of select="entity/@XSCodeGen"/>
		<xsl:text>
Model v 0.2 2006-05-28
*************************************************************************/
using System;

namespace </xsl:text>
		<xsl:value-of select="entity/@namespace"/>
		<xsl:text>.Model
{
</xsl:text>
		<xsl:apply-templates select="entity"/>
		<xsl:text>
}
</xsl:text>
	</xsl:template>
	<xsl:template match="entity">
		<xsl:text>
	/// &lt;summary&gt;
	/// </xsl:text>
		<xsl:value-of select="@name"/>
		<xsl:text> is an entity class that represents </xsl:text>
		<xsl:value-of select="@description"/>
		<xsl:text>. </xsl:text>
		<xsl:text>
	/// &lt;/summary&gt;
	[Serializable]
	public class </xsl:text>
		<xsl:value-of select="@name"/><xsl:text>Info</xsl:text>
		<xsl:text>
	{
		#region declaration</xsl:text>
		<xsl:for-each select="./columns/property">
			<xsl:text>
		private </xsl:text>
			<xsl:value-of select="@type"/>
			<xsl:text> </xsl:text>
			<xsl:value-of select="@field"/>
			<xsl:text>;</xsl:text>
		</xsl:for-each>
		<xsl:text>
		#endregion</xsl:text>		
		<xsl:text>
		#region constructors
		/// &lt;summary&gt;
        /// Default constructor
        /// &lt;/summary&gt;
		public </xsl:text>
		<xsl:value-of select="@name"/>Info<xsl:text>() { }
		</xsl:text>
		<xsl:text>		
		/// &lt;summary&gt;
        /// Full constructor
        /// &lt;/summary&gt;
		public </xsl:text>
		<xsl:value-of select="@name"/>Info(<xsl:for-each select="./columns/property">
			<xsl:value-of select="@type"/>
			<xsl:text> </xsl:text>
			<xsl:value-of select="@lowerName"/>			
			<xsl:if test="position()!=last()">
				<xsl:text>, </xsl:text>
			</xsl:if>
		</xsl:for-each>)
        {<xsl:for-each select="./columns/property">
			<xsl:text>
			this.</xsl:text>
			<xsl:value-of select="@field"/>
			<xsl:text> = </xsl:text>
			<xsl:value-of select="@lowerName"/>
			<xsl:text>;</xsl:text>
		</xsl:for-each>
		<xsl:text>
        }        
		#endregion
		</xsl:text>
		<xsl:text>
		#region property</xsl:text>
		<xsl:for-each select="./columns/property">
			<xsl:text>
		/// &lt;summary&gt;
		/// </xsl:text>
			<xsl:value-of select="@name"/>
			<xsl:text> is a </xsl:text>
			<xsl:value-of select="@type"/>
			<xsl:text> property that represents </xsl:text>
			<xsl:value-of select="@description"/>
			<xsl:text>. </xsl:text>
			<xsl:text>
		/// &lt;/summary&gt;
		public </xsl:text>
			<xsl:value-of select="@type"/>
			<xsl:text> </xsl:text>
			<xsl:value-of select="@name"/>
			<xsl:text>
		{
			get	{ return </xsl:text>
			<xsl:value-of select="@field"/>
			<xsl:text>; }
			set	{ </xsl:text>
			<xsl:value-of select="@field"/>
			<xsl:text> = value; }
		}</xsl:text>
		</xsl:for-each>
		<xsl:text>
		#endregion</xsl:text>
		<xsl:text>
	}</xsl:text>
	</xsl:template>
</xsl:stylesheet>
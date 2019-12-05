<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output omit-xml-declaration="yes" indent="no" method="text" encoding="UTF-8"/>
	<xsl:template match="/">
		<xsl:text>using System;
using System.Web.UI.WebControls;

using SouEi.BLL;

namespace </xsl:text>
		<xsl:value-of select="entity/@namespace"/>
		<xsl:text>.SmartMoney.Admin
{</xsl:text>
		<xsl:apply-templates select="entity"/>
		<xsl:text>
}</xsl:text>
	</xsl:template>
	<xsl:template match="entity">
	public partial class Admin_<xsl:value-of select="@name"/>List : SouEi.SmartMoney.Admin.AdminListBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            base.ManageTable = "<xsl:value-of select="@name"/>";
            base.ManageKey = "<xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>";

            BLL.<xsl:value-of select="@name"/> ad = new BLL.<xsl:value-of select="@name"/>();
            myManageGrid.DataSource = ad.GetList("");
            if (!IsPostBack)
            {
                myManageGrid.DataBind();
            }
        }

        public override void getData()
        {
            BLL.<xsl:value-of select="@name"/> ad = new BLL.<xsl:value-of select="@name"/>();
            myManageGrid.DataSource = ad.GetList("");
            myManageGrid.DataBind();
        }
	}</xsl:template>
</xsl:stylesheet>
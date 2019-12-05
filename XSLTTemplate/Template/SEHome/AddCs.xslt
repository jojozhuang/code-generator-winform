<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output omit-xml-declaration="yes" indent="no" method="text" encoding="UTF-8"/>
	<xsl:template match="/">
		<xsl:text>using System;
using System.Web.UI.WebControls;

using SouEi.Model;
using SouEi.CommonBase;

namespace </xsl:text>
		<xsl:value-of select="entity/@namespace"/>
		<xsl:text>.SmartMoney.Admin
{</xsl:text>
		<xsl:apply-templates select="entity"/>
		<xsl:text>
}</xsl:text>
	</xsl:template>
	<xsl:template match="entity">
	public partial class Admin_<xsl:value-of select="@name"/>Add : AdminBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            
            if (!this.IsPostBack)
            {
                if (Request.QueryString["action"] == "modify")
                {
                    //get <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>
                    int <xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each> = Convert.ToInt32(Request.QueryString["id"]);

                    //<xsl:value-of select="@name"/> entity
                    BLL.<xsl:value-of select="@name"/> bll = new BLL.<xsl:value-of select="@name"/>();

                    //bind data
                    Model.<xsl:value-of select="@modelName"/> model = new Model.<xsl:value-of select="@modelName"/>();
                    model = bll.GetModel(<xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each>);
            
					<xsl:for-each select="./columns/property">
						<xsl:if test="@identity!='True'">
			            	<xsl:text>txt</xsl:text>
			            	<xsl:value-of select="@name"/>
			            	<xsl:text>.Text = model.</xsl:text>
			            	<xsl:value-of select="@name"/>
			            	<xsl:text>;
					</xsl:text>
			            </xsl:if>
					</xsl:for-each>					
                    btnAdd.Text = "Update";
                }
            }
		}
		
		protected void btnAdd_Click(object sender, System.EventArgs e)
        {
			<xsl:for-each select="./columns/property">
				<xsl:if test="@identity!='True'">
				<xsl:if test="@nullable='False'">
            		<xsl:text>if (txt</xsl:text>
            		<xsl:value-of select="@name"/>
            		<xsl:text>.Text == String.Empty)</xsl:text>
	    	{
	            Jscript.Alert("Please input the <xsl:value-of select="@name"/>");
	            txt<xsl:value-of select="@name"/>.Focus();
	            return;
	        }
			</xsl:if>
				</xsl:if>
			</xsl:for-each>
            BLL.<xsl:value-of select="@name"/> bll = new BLL.<xsl:value-of select="@name"/>();
            Model.<xsl:value-of select="@modelName"/> model = new Model.<xsl:value-of select="@modelName"/>();

            if (Request.QueryString["action"] == "modify")
            {
                //update
                model.<xsl:for-each select="./primaryKey/column">
            <xsl:value-of select="@columnName"/></xsl:for-each> = Convert.ToInt32(Request.QueryString["id"]);
                <xsl:for-each select="./columns/property">
	                <xsl:if test="@identity!='True'">
		            	<xsl:text>model.</xsl:text>
		            	<xsl:value-of select="@name"/>
		            	<xsl:text> = txt</xsl:text>
		            	<xsl:value-of select="@name"/>
		            	<xsl:text>.Text;
				</xsl:text>
		            </xsl:if>
				</xsl:for-each>
                bll.Update(model);
                Jscript.Alert("Success to update!");
            }
            else
            {
                //insert
                <xsl:for-each select="./columns/property">
	                <xsl:if test="@identity!='True'">
		            	<xsl:text>model.</xsl:text>
		            	<xsl:value-of select="@name"/>
		            	<xsl:text> = txt</xsl:text>
		            	<xsl:value-of select="@name"/>
		            	<xsl:text>.Text;
				</xsl:text>
		            </xsl:if>
				</xsl:for-each>
                if (bll.Add(model) > 0)
                {
                    Jscript.Alert("Success to insert!!!");
                    <xsl:for-each select="./columns/property">
		                <xsl:if test="@identity!='True'">
			            	<xsl:text>txt</xsl:text>
			            	<xsl:value-of select="@name"/>
			            	<xsl:text>.Text = "";
			        </xsl:text>
			            </xsl:if>
					</xsl:for-each>
                }
                else
                    Jscript.Alert("Fail to insert!");                
            }
        }          
	}</xsl:template>
</xsl:stylesheet>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="IBSC.UI.Web.Page.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="services-header">
        <div class="primary-dark-div">
            <div class="container">
                <div class="row">
                    <div class="col-sm-7 col-md-7">
                        <div class="service-header-text">
                            <h1 class="animated fadeInDownBig animation-delay-6 margin-top-10">ประกันภัยออนไลน์ <small>"The Digital Broker"</small></h1>
                            <p class="animated fadeInDownBig animation-delay-5 slide-subtitle">โบรกเกอร์ประกันภัยออนไลน์รูปแบบใหม่ ลูกค้าสามารถเช็คราคา และสั่งซื้อประกันภัยรถยนต์มากกว่า 30 บริษัทประกัน</p>
                            <ul class="list-unstyled carousel-list" style="margin-left: 50px;">
                                <li><i class="fa fa-check"></i>การันตีราคาดีที่สุด</li>
                                <li><i class="fa fa-check"></i>คุ้มครองทันที</li>
                                <li><i class="fa fa-check"></i>ฟรี บริการจัดส่ง</li>
                            </ul>

                            <!-- 				<p class="margin-top-30 animated fadeInUp animation-delay-8 hidden-xs" style="font-size: 16px;">
								<a href="#" class="button button-primary button-circle button-small"><i class="fa fa-automobile"></i></a>
								&nbsp;ประกันภัยรถยนต์
								&nbsp;&nbsp;&nbsp;
								<a href="#" class="button button-primary button-circle button-small"><i class="fa fa-plane"></i></a>
								&nbsp;ประกันภัยการเดินทาง
							</p> -->
                            <div class="row icon-link hidden">
                                <div class="col-xs-4 col-sm-2 col-sm-offset-3 text-center">
                                    <div id="link_cal">
                                        <a id="ContentPlaceHolder_HyperLink15" href="#tools_cal">
                                            <img id="ContentPlaceHolder_Image12" class="img-responsive img-circle center-block" src="images/icon-cal.jpg"></a>
                                    </div>
                                </div>
                                <div class="col-xs-4 col-sm-2 text-center">
                                    <a id="ContentPlaceHolder_HyperLink16" href="http://ancbroker.com/2014/member/">
                                        <img id="ContentPlaceHolder_Image13" class="img-responsive img-circle center-block" src="images/icon-login.jpg">
                                        เข้าสู่ระบบ
                                    </a>
                                </div>
                                <div class="col-md-3 col-lg-2 text-center hidden-xs hidden-sm">
                                    <img id="ContentPlaceHolder_Image16" class="img-responsive center-block" src="images/line-anc.jpg">
                                    เพิ่มเพื่อน
                                </div>
                                <div class="col-xs-4 col-sm-2 text-center hidden-md hidden-lg">
                                    <a id="ContentPlaceHolder_HyperLink14" href="https://line.me/ti/p/%40xgy6328r">
                                        <img id="ContentPlaceHolder_Image18" class="img-responsive img-circle center-block" src="images/icon-line.jpg">
                                        เพิ่มเพื่อน
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-5 col-md-5">
                        <div class="cal_motor animated fadeInRight animation-delay-8">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h2 class="text-center margin-bottom-10">เช็คราคาประกันภัย<span>รถยนต์</span></h2>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div id="ContentPlaceHolder_ucGetPrice_PanelCal" onkeypress="javascript:return WebForm_FireDefaultButton(event, 'ContentPlaceHolder_ucGetPrice_btCal')">

                                        <fieldset>
                                            <script type="text/javascript">
                                                //<![CDATA[
                                                Sys.WebForms.PageRequestManager._initialize('ctl00$ContentPlaceHolder$ucGetPrice$ScriptManager1', 'form1', ['tctl00$ContentPlaceHolder$ucGetPrice$UpdatePanel1', 'ContentPlaceHolder_ucGetPrice_UpdatePanel1'], [], [], 90, 'ctl00');
                                                //]]>
                                            </script>

                                            <div id="ContentPlaceHolder_ucGetPrice_UpdatePanel1">

                                                <div class="form-group">
                                                    <select name="ctl00$ContentPlaceHolder$ucGetPrice$ddlCarYear" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder$ucGetPrice$ddlCarYear\',\'\')', 0)" id="ContentPlaceHolder_ucGetPrice_ddlCarYear" class="form-control">
                                                        <option selected="selected" value="0">- ปีรถยนต์ -</option>
                                                        <option value="2016">2016</option>
                                                        <option value="2015">2015</option>
                                                        <option value="2014">2014</option>
                                                        <option value="2013">2013</option>
                                                        <option value="2012">2012</option>
                                                        <option value="2011">2011</option>
                                                        <option value="2010">2010</option>
                                                        <option value="2009">2009</option>
                                                        <option value="2008">2008</option>
                                                        <option value="2007">2007</option>
                                                        <option value="2006">2006</option>
                                                        <option value="2005">2005</option>
                                                        <option value="2004">2004</option>
                                                        <option value="2003">2003</option>
                                                        <option value="2002">2002</option>

                                                    </select>
                                                </div>
                                                <div class="form-group">
                                                    <select name="ctl00$ContentPlaceHolder$ucGetPrice$ddlCarBrand" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder$ucGetPrice$ddlCarBrand\',\'\')', 0)" id="ContentPlaceHolder_ucGetPrice_ddlCarBrand" class="form-control">
                                                        <option selected="selected" value="0">- ยี่ห้อรถ -</option>
                                                        <option value="HONDA">HONDA</option>
                                                        <option value="TOYOTA">TOYOTA</option>
                                                    </select>
                                                </div>
                                                <div class="form-group">
                                                    <select name="ctl00$ContentPlaceHolder$ucGetPrice$ddlCarModel" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder$ucGetPrice$ddlCarModel\',\'\')', 0)" id="ContentPlaceHolder_ucGetPrice_ddlCarModel" class="form-control">
                                                        <option value="0">- รุ่นรถ -</option>
                                                        <option value="CITY">CITY</option>
                                                        <option value="VIOS">VIOS</option>
                                                    </select>
                                                </div>

                                            </div>
                                            <div class="form-group">
                                                <%--<input type="submit" name="ctl00$ContentPlaceHolder$ucGetPrice$btCal" value="ยืนยันข้อมูล" id="ContentPlaceHolder_ucGetPrice_btCal" class="button button-3d button-primary button-rounded btn-block">--%>
                                                <asp:Button ID="Button1" runat="server" Text="ยืนยันข้อมูล" class="button button-3d button-primary button-rounded btn-block" OnClick="Button1_Click" PostBackUrl="~/Page/InsuranceCheck.aspx" />
                                            </div>
                                        </fieldset>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <section class="wrap-dark-color step-buy">
        <div class="container">
            <div class="row">
                <div class="col-md-5 hidden-sm hidden-xs">
                    <h3>ประกันรถยนต์ ประเภทต่างๆ</h3>
                    <p class="lead">เรารวบรวมแบบประกันภัยจากบริษัทประกันภัยชั้นนำของประเทศมาให้เปรียบเทียบทั้งความคุ้มครองและราคาที่เหมาะสมกับท่าน</p>
                </div>
                <div class="col-md-7 feature-container">
                    <a id="ContentPlaceHolder_HyperLink17" class="feature-icon" href="InsuranceCheck.aspx">
                        <p>1</p>
                        <h4>ประเภท</h4>
                    </a>
                    <a id="ContentPlaceHolder_HyperLink18" class="feature-icon" href="InsuranceCheck.aspx">
                        <p>2+</p>
                        <h4>ประเภท</h4>
                    </a>
                    <a id="ContentPlaceHolder_HyperLink19" class="feature-icon" href="InsuranceCheck.aspx">
                        <p>3+</p>
                        <h4>ประเภท</h4>
                    </a>
                    <a id="ContentPlaceHolder_HyperLink20" class="feature-icon" href="InsuranceCheck.aspx">
                        <p>3</p>
                        <h4>ประเภท</h4>
                    </a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

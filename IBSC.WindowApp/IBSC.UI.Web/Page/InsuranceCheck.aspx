<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.Master" AutoEventWireup="true" CodeBehind="InsuranceCheck.aspx.cs" Inherits="IBSC.UI.Web.Page.InsuranceCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        //Model Size
        $(document).ready(ajustamodal);
        $(window).resize(ajustamodal);

        $(document).ready(function () {
            $(":checkbox").labelauty({
                label: false,
            });

            $('#anc-profile').bxSlider({
                hideControlOnEnd: true,
                minSlides: 5,
                maxSlides: 5,
                slideWidth: 240,
                slideMargin: 10,
                pager: false,

            });

            $('#anc-review').bxSlider({
                hideControlOnEnd: true,
                minSlides: 1,
                maxSlides: 1,
                slideMargin: 10,
                pager: false,
                nextSelector: '#bx-next',
                prevSelector: '#bx-prev',
                nextText: '<i class="fa fa-angle-right"></i>',
                prevText: '<i class="fa fa-angle-left"></i>'
            });
        });

        function ajustamodal() {
            var altura = $(window).height() - 190; //value corresponding to the modal heading + footer
            $(".ativa-scroll").css({ "height": altura, "overflow-y": "auto" });
        }

        (function ($) {
            $(document).ready(function () {
                var countCK = countCheckbox();
                $('#btn_compare').html("เปรียบเทียบเบี้ย (" + countCK + ")");
            });
        })(jQuery);

        $("input:checkbox").click(function () {
            var countCK = countCheckbox();

            if (countCK > 3) {
                alert("เลือกได้ไม่เกิน 3 รายการ");
                return false;
            }
            else {
                $('#btn_compare').html("เปรียบเทียบเบี้ย (" + countCK + ")");
            }
        });

        function countCheckbox() {
            var ckClass = document.getElementsByClassName('styled');
            var countCK = 0;

            for (var i = 0; i < ckClass.length; i++) {
                if (ckClass.item(i).checked == true) {
                    countCK++;
                }
            }

            return countCK;
        }

        function calCheckbox() {

            var countCK = countCheckbox();

            if (countCK < 1) {
                alert("กรุณาเลือกอย่างน้อย 1 รายการ");
            }
            else if (countCK <= 3) {

                if (countCK == 1) {
                    $("#p_c0").attr('class', 'col-md-6 hidden-sm hidden-xs pricing-col');
                    $("#p_c1").attr('class', 'col-md-6 pricing-col');
                    $("#p_c2").attr('class', 'hidden');
                    $("#p_c3").attr('class', 'hidden');

                    $("#p_t1").attr('class', 'pricing-table border-fix-pricing');
                }
                else if (countCK == 2) {
                    $("#p_c0").attr('class', 'col-md-4 hidden-sm hidden-xs pricing-col');
                    $("#p_c1").attr('class', 'col-md-4 pricing-col');
                    $("#p_c2").attr('class', 'col-md-4 pricing-col');
                    $("#p_c3").attr('class', 'hidden');

                    $("#p_t1").attr('class', 'pricing-table');
                    $("#p_t2").attr('class', 'pricing-table border-fix-pricing');
                }
                else {
                    $("#p_c0").attr('class', 'col-md-3 hidden-sm hidden-xs pricing-col');
                    $("#p_c1").attr('class', 'col-md-3 pricing-col');
                    $("#p_c2").attr('class', 'col-md-3 pricing-col');
                    $("#p_c3").attr('class', 'col-md-3 pricing-col');

                    $("#p_t1").attr('class', 'pricing-table');
                    $("#p_t2").attr('class', 'pricing-table');
                    $("#p_t3").attr('class', 'pricing-table border-fix-pricing');
                }

                var count_int = 1;
                var inputElems = document.getElementsByClassName("styled");

                for (var i = 0; i < inputElems.length; i++) {
                    if (inputElems[i].checked) {
                        var s = inputElems[i].value;
                        var ss = s.split("|");

                        document.getElementById('lbINSName' + count_int).innerHTML = ss[1];
                        document.getElementById('lbPACKNAME' + count_int).innerHTML = ss[2];
                        document.getElementById('lbFIX' + count_int).innerHTML = ss[3];
                        document.getElementById('lbNETPREMIUM' + count_int).innerHTML = ss[4];
                        document.getElementById('lbBI' + count_int).innerHTML = ss[5];
                        document.getElementById('lbBT' + count_int).innerHTML = ss[6];
                        document.getElementById('lbTP' + count_int).innerHTML = ss[7];
                        document.getElementById('lbOD' + count_int).innerHTML = ss[8];
                        document.getElementById('lbFIRE' + count_int).innerHTML = ss[9];
                        document.getElementById('lbODDD' + count_int).innerHTML = ss[10];
                        document.getElementById('lbFLOOD' + count_int).innerHTML = ss[11];
                        document.getElementById('lbPA' + count_int).innerHTML = ss[13];
                        document.getElementById('lbME' + count_int).innerHTML = ss[14];
                        document.getElementById('lbBB' + count_int).innerHTML = ss[15];
                        $("#linkBuy" + count_int).attr('href', ss[18]);
                        //$("#linkBuy" + count_int).attr('href', 'http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?REF1=' + ss[16] + '&REF2=' + ss[17]);
                        count_int = count_int + 1;
                    }
                }

                $('#package_compare').modal('show');
            }
            else if (countCK > 3) {
                alert("เลือกได้ไม่เกิน 3 รายการ");
            }
            else {
                alert("Error");
            }
        }
    </script>

    <div class="container">
        <div class="row">
            <div class="col-md-6 topic padding-top-20">
                <img id="ContentPlaceHolder_imgBrand" class="img-circle img-responsive pull-left" src="../logoCar/AUDI.png" />
                <h1 class="no-margin hideOverflow">
                    <asp:Label ID="lblCarName" runat="server" Text="CarName CarModel CarEngine ปีCarYear" Style="font-size: xx-large; color: hotpink;"></asp:Label></h1>
                ประกันภัยรถยนต์ ชั้น1
				<div class="clearfix"></div>
            </div>
            <div class="col-md-6">
                <blockquote>
                    <p>
                        รายการ <b>ประกันภัยรถยนต์ ชั้น1</b>
                        <asp:Label ID="lblCarNameDesc" runat="server" Text="CarName CarModel CarEngine ปีCarYear"></asp:Label>
                        ทุกบริษัทประกันราคาพิเศษ คุ้มครองครอบคลุมทุกความเสี่ยง ทั้งชน รถหาย ไฟไหม้ เหมาะกับผู้ที่ใช้รถเป็นประจำและหมดกังวลทุกการขับขี่
                    </p>
                    <footer><b><span id="ContentPlaceHolder_lbCPType">ประกันภัยรถยนต์ ชั้น1</span></b></footer>
                </blockquote>
            </div>
        </div>
        <hr class="no-margin-top" />

        <div class="row">
            <div class="col-md-4">
                <%-- <div class="btn-group btn-group-justified margin-bottom-10">
                    <a id="ContentPlaceHolder_linkCarType1" class="btn btn-primary">ชั้น1</a>
                </div>--%>
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading panel-heading-link">
                            <a data-toggle="collapse" data-parent="#accordioncc3" href="#cal_ins" id="cal_panel" class="" aria-expanded="true">ค้นหาประกันภัยรถยนต์</a>
                        </div>
                        <div id="cal_ins" class="panel-collapse collapse in" aria-expanded="true">
                            <div id="ContentPlaceHolder_Panel1" class="panel-body" onkeypress="javascript:return WebForm_FireDefaultButton(event, 'ContentPlaceHolder_btCal')">

                                <script type="text/javascript">
                                    //<![CDATA[
                                    Sys.WebForms.PageRequestManager._initialize('ctl00$ContentPlaceHolder$ScriptManager1', 'form1', ['tctl00$ContentPlaceHolder$UpdatePanel1', 'ContentPlaceHolder_UpdatePanel1'], [], [], 90, 'ctl00');
                                    //]]>
                                </script>

                                <div id="ContentPlaceHolder_UpdatePanel1">
                                    <div class="form-group">
                                        <label for="select">ปีรถ</label>
                                         <asp:DropDownList ID="ddlCarYear" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Text="กรุณาเลือก" Value="0" />
                                             <asp:ListItem Text="2017" Value="1" />
                                             <asp:ListItem Text="2016" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="select">ยี่ห้อรถ</label>
                                         <asp:DropDownList ID="ddlCarName" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Text="กรุณาเลือก" Value="0" />
                                             <asp:ListItem Text="AUDI" Value="1" />
                                             <asp:ListItem Text="BMW" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="select">รุ่นรถ</label>
                                        <asp:DropDownList ID="ddlCarModel" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Text="กรุณาเลือก" Value="0" />
                                             <asp:ListItem Text="A4" Value="1" />
                                             <asp:ListItem Text="Q3" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                     <div class="form-group">
                                        <label for="select">เครื่องยนต์</label>
                                        <asp:DropDownList ID="ddlCarEngine" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Text="กรุณาเลือก" Value="0" />
                                             <asp:ListItem Text="2.0cc 4 Door" Value="1" />
                                             <asp:ListItem Text="2.0cc 4 Door" Value="2" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:Button ID="btnSearch" runat="server" Text="ยืนยันข้อมูล" class="btn btn-ar btn-primary" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-6 margin-bottom-20">
                    </div>
                    <div class="col-md-12 col-sm-6 margin-bottom-20">
                    </div>
                    <div class="col-md-12 col-sm-6 margin-bottom-20">
                    </div>
                    <div class="col-md-12 col-sm-6 margin-bottom-20">
                    </div>
                    <div class="col-md-12 col-sm-6">
                    </div>
                </div>
            </div>


            <div class="col-md-8">
                <div class="row">
                    <div class="col-xs-12">
                        <a href="javascript:void(0)" id="btn_compare" class="button button-highlight button-rounded button-small padding-h-10 pull-right btn-compare" onclick="calCheckbox()">เปรียบเทียบเบี้ย</a>
                        <div class="modal fade" id="package_compare" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                        <h4 class="modal-title" id="myModalLabel">รายละเอียดประกัน ชั้น1</h4>
                                    </div>

                                    <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">

                                        <div id="p_c0" class="col-md-3 hidden-sm hidden-xs pricing-col">
                                            <div id="p_t0" class="pricing-table pricing-table-description">
                                                <div class="pricing-table-head">
                                                    <h3 class="pricing-desc-title">ความคุ้มครอง</h3>
                                                </div>
                                                <ul class="pricing-table-content">
                                                    <li><i class="fa fa-wrench"></i>ซ่อม</li>
                                                    <li><i class="fa fa-car"></i>ความคุ้มครองบุคคลภายนอก</li>
                                                    <li>- ชีวิต ร่างกาย หรืออนามัย</li>
                                                    <li>- ชีวิต ร่างกาย หรืออนามัย</li>
                                                    <li>- ทรัพย์สิน</li>
                                                    <li><i class="fa fa-car"></i>ความคุ้มครองผู้เอาประกัน</li>
                                                    <li>- ความเสียหายต่อตัวรถยนต์</li>
                                                    <li>- สูญหายหรือไฟไหม้</li>
                                                    <li>- ค่าความเสียหายส่วนแรก</li>
                                                    <li>- ประกันน้ำท่วม</li>
                                                    <li>- อุบัติเหตุส่วนบุคคล</li>
                                                    <li>- ค่ารักษาพยาบาล 7 ที่นั่ง</li>
                                                    <li>- ประกันตัวผู้ขับขี่</li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div id="p_c1" class="col-md-3 pricing-col">
                                            <div id="p_t1" class="pricing-table">
                                                <div class="pricing-table-head">
                                                    <h2><span class="ins-name hideOverflow" id="lbINSName1"></span><span class="pack-name hideOverflow" id="lbPACKNAME1"></span></h2>
                                                    <h3 class="price">฿ <i id="lbNETPREMIUM1"></i></h3>
                                                </div>
                                                <ul class="pricing-table-content">
                                                    <li><span class="hidden-md hidden-lg">ซ่อม</span><span id="lbFIX1"></span></li>
                                                    <li><span class="hidden-md hidden-lg">คุ้มครองบุคคลภายนอก</span>วงเงิน (บาท)</li>
                                                    <li><span class="hidden-md hidden-lg">ชีวิต ร่างกาย หรืออนามัย</span><span id="lbBI1"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ชีวิต ร่างกาย หรืออนามัย</span><span id="lbBT1"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ทรัพย์สิน</span><span id="lbTP1"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">คุ้มครองผู้เอาประกัน</span>วงเงิน (บาท)</li>
                                                    <li><span class="hidden-md hidden-lg">ความเสียหายต่อตัวรถยนต์</span><span id="lbOD1"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">สูญหายหรือไฟไหม้</span><span id="lbFIRE1"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ค่าความเสียหายส่วนแรก</span><span id="lbODDD1"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ประกันน้ำท่วม</span><span id="lbFLOOD1"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">อุบัติเหตุส่วนบุคคล</span><span id="lbPA1"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ค่ารักษาพยาบาล</span><span id="lbME1"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ประกันตัวผู้ขับขี่</span><span id="lbBB1"></span> / คน</li>
                                                </ul>
                                                <div class="pricing-table-footer">
                                                    <a id="linkBuy1" href="#" target="_blank" class="btn btn-ar btn-block btn-success"><i class="fa fa-shopping-cart"></i>ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="p_c2" class="col-md-3 pricing-col">
                                            <div id="p_t2" class="pricing-table">
                                                <div class="pricing-table-head">
                                                    <h2><span class="ins-name hideOverflow" id="lbINSName2"></span><span class="pack-name hideOverflow" id="lbPACKNAME2"></span></h2>
                                                    <h3 class="price">฿ <i id="lbNETPREMIUM2"></i></h3>
                                                </div>
                                                <ul class="pricing-table-content">
                                                    <li><span class="hidden-md hidden-lg">ซ่อม</span><span id="lbFIX2"></span></li>
                                                    <li><span class="hidden-md hidden-lg">คุ้มครองบุคคลภายนอก</span>วงเงิน (บาท)</li>
                                                    <li><span class="hidden-md hidden-lg">ชีวิต ร่างกาย หรืออนามัย</span><span id="lbBI2"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ชีวิต ร่างกาย หรืออนามัย</span><span id="lbBT2"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ทรัพย์สิน</span><span id="lbTP2"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">คุ้มครองผู้เอาประกัน</span>วงเงิน (บาท)</li>
                                                    <li><span class="hidden-md hidden-lg">ความเสียหายต่อตัวรถยนต์</span><span id="lbOD2"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">สูญหายหรือไฟไหม้</span><span id="lbFIRE2"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ค่าความเสียหายส่วนแรก</span><span id="lbODDD2"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ประกันน้ำท่วม</span><span id="lbFLOOD2"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">อุบัติเหตุส่วนบุคคล</span><span id="lbPA2"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ค่ารักษาพยาบาล</span><span id="lbME2"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ประกันตัวผู้ขับขี่</span><span id="lbBB2"></span> / คน</li>
                                                </ul>
                                                <div class="pricing-table-footer">
                                                    <a id="linkBuy2" href="#" target="_blank" class="btn btn-ar btn-block btn-success"><i class="fa fa-shopping-cart"></i>ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="p_c3" class="col-md-3 pricing-col">
                                            <div id="p_t3" class="pricing-table border-fix-pricing">
                                                <div class="pricing-table-head">
                                                    <h2><span class="ins-name hideOverflow" id="lbINSName3"></span><span class="pack-name hideOverflow" id="lbPACKNAME3"></span></h2>
                                                    <h3 class="price">฿ <i id="lbNETPREMIUM3"></i></h3>
                                                </div>
                                                <ul class="pricing-table-content">
                                                    <li><span class="hidden-md hidden-lg">ซ่อม</span><span id="lbFIX3"></span></li>
                                                    <li><span class="hidden-md hidden-lg">คุ้มครองบุคคลภายนอก</span>วงเงิน (บาท)</li>
                                                    <li><span class="hidden-md hidden-lg">ชีวิต ร่างกาย หรืออนามัย</span><span id="lbBI3"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ชีวิต ร่างกาย หรืออนามัย</span><span id="lbBT3"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ทรัพย์สิน</span><span id="lbTP3"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">คุ้มครองผู้เอาประกัน</span>วงเงิน (บาท)</li>
                                                    <li><span class="hidden-md hidden-lg">ความเสียหายต่อตัวรถยนต์</span><span id="lbOD3"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">สูญหายหรือไฟไหม้</span><span id="lbFIRE3"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ค่าความเสียหายส่วนแรก</span><span id="lbODDD3"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">ประกันน้ำท่วม</span><span id="lbFLOOD3"></span> / ครั้ง</li>
                                                    <li><span class="hidden-md hidden-lg">อุบัติเหตุส่วนบุคคล</span><span id="lbPA3"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ค่ารักษาพยาบาล</span><span id="lbME3"></span> / คน</li>
                                                    <li><span class="hidden-md hidden-lg">ประกันตัวผู้ขับขี่</span><span id="lbBB3"></span> / คน</li>
                                                </ul>
                                                <div class="pricing-table-footer">
                                                    <a id="linkBuy3" href="#" target="_blank" class="btn btn-ar btn-block btn-success"><i class="fa fa-shopping-cart"></i>ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-ar btn-sm btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <hr class="margin-10">

                <div class="row">
                    <div class="col-xs-12">
                        <div class="owl-card owl-carousel owl-theme owl-responsive-1000 owl-loaded">
                            <div class="owl-stage-outer">
                                <div class="owl-stage" style="transform: translate3d(0px, 0px, 0px); transition: 0s; width: 759.999px;">
                                    <div class="owl-item active" style="width: 243.333px; margin-right: 10px;">
                                        <div id="ContentPlaceHolder_card1" class="item">
                                            <div class="pricign-box animated fadeInUp animation-delay-7">
                                                <div class="pricing-box-header">
                                                    <h2>แนะนำ</h2>
                                                    <p id="ContentPlaceHolder_cardINSName1" class="hideOverflow">วิริยะประกันภัย</p>
                                                </div>
                                                <div class="pricing-box-price">
                                                    <h3 id="ContentPlaceHolder_cardNETPREMIUM1">฿ 48600</h3>
                                                </div>
                                                <div class="pricing-box-content">
                                                    <ul>
                                                        <li id="ContentPlaceHolder_cardPACKNAME1" class="text-center hideOverflow">VBI ป1 เก๋งอู่ (S30)</li>
                                                        <li><i class="fa fa-wrench"></i>ซ่อม<span id="ContentPlaceHolder_cardFIX1" class="pull-right">อู่</span></li>
                                                        <li><i class="fa fa-car"></i>ทุน<span id="ContentPlaceHolder_cardOD1" class="pull-right">2,200,000</span></li>
                                                        <li><i class="fa fa-share-alt"></i>เสียหายส่วนแรก<span id="ContentPlaceHolder_cardODDD1" class="pull-right text-danger">-</span></li>
                                                    </ul>
                                                </div>
                                                <div class="pricing-box-footer">
                                                    <div class="row">
                                                        <div class="col-xs-4">
                                                            <input name="ctl00$ContentPlaceHolder$mc1_Compare" type="checkbox" id="ContentPlaceHolder_mc1_Compare" class="styled labelauty" value="VBI|วิริยะประกันภัย|VBI ป1 เก๋งอู่ (S30)|อู่|48600|1,000,000|10,000,000|5,000,000|2,200,000|2,200,000|-|2,200,000|7|200,000|200,000|200,000|20161119212744_FY_144189|289|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AD%E0%B8%B9%E0%B9%88+%28S30%29&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_netpre=47432.54&amp;pack_pre=50956.12&amp;pack_offerprice=48600&amp;pack_offerdiscount=2356.12&amp;pack_id=1834&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=289" style="display: none;"/><label for="ContentPlaceHolder_mc1_Compare"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                                        </div>
                                                        <div class="col-xs-8">
                                                            <a href="#" class="btn btn-ar btn-default mar-l-10" data-toggle="modal" data-target="#modalCard1">ดูรายละเอียด</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 243.333px; margin-right: 10px;">
                                        <div id="ContentPlaceHolder_card2" class="item">
                                            <div class="pricign-box animated fadeInUp animation-delay-8">
                                                <div class="pricing-box-header">
                                                    <h2>แนะนำ</h2>
                                                    <p id="ContentPlaceHolder_cardINSName2" class="hideOverflow">วิริยะประกันภัย</p>
                                                </div>
                                                <div class="pricing-box-price">
                                                    <h3 id="ContentPlaceHolder_cardNETPREMIUM2">฿ 53400</h3>
                                                </div>
                                                <div class="pricing-box-content">
                                                    <ul>
                                                        <li id="ContentPlaceHolder_cardPACKNAME2" class="text-center hideOverflow">VBI ป1 เก๋งห้าง (AS6) STD</li>
                                                        <li><i class="fa fa-wrench"></i>ซ่อม<span id="ContentPlaceHolder_cardFIX2" class="pull-right">ห้าง</span></li>
                                                        <li><i class="fa fa-car"></i>ทุน<span id="ContentPlaceHolder_cardOD2" class="pull-right">2,200,000</span></li>
                                                        <li><i class="fa fa-share-alt"></i>เสียหายส่วนแรก<span id="ContentPlaceHolder_cardODDD2" class="pull-right text-danger">-</span></li>
                                                    </ul>
                                                </div>
                                                <div class="pricing-box-footer">
                                                    <div class="row">
                                                        <div class="col-xs-4">
                                                            <input name="ctl00$ContentPlaceHolder$mc2_Compare" type="checkbox" id="ContentPlaceHolder_mc2_Compare" class="styled labelauty" value="VBI|วิริยะประกันภัย|VBI ป1 เก๋งห้าง (AS6) STD|ห้าง|53400|1,000,000|10,000,000|5,000,000|2,200,000|2,200,000|-|2,200,000|7|500,000|500,000|500,000|20161119212744_FY_144189|83|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87+%28AS6%29+STD&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=52095.54&amp;pack_pre=55965.86&amp;pack_offerprice=53400&amp;pack_offerdiscount=2565.86&amp;pack_id=957&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=83" style="display: none;"><label for="ContentPlaceHolder_mc2_Compare"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                                        </div>
                                                        <div class="col-xs-8"><a href="#" class="btn btn-ar btn-default" data-toggle="modal" data-target="#modalCard2">ดูรายละเอียด</a></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 243.333px; margin-right: 10px;">
                                        <div id="ContentPlaceHolder_card3" class="item">
                                            <div class="pricign-box-p animated fadeInUp animation-delay-9">
                                                <div class="pricing-box-header">
                                                    <h2>&nbsp;</h2>
                                                    <p id="ContentPlaceHolder_cardINSName3" class="hideOverflow">วิริยะประกันภัย</p>
                                                </div>
                                                <div class="pricing-box-price">
                                                    <h3 id="ContentPlaceHolder_cardNETPREMIUM3">฿ 53400</h3>
                                                </div>
                                                <div class="pricing-box-content">
                                                    <ul>
                                                        <li id="ContentPlaceHolder_cardPACKNAME3" class="text-center hideOverflow">VBI ป1 เก๋งห้าง (AS6) STD</li>
                                                        <li><i class="fa fa-wrench"></i>ซ่อม<span id="ContentPlaceHolder_cardFIX3" class="pull-right">ห้าง</span></li>
                                                        <li><i class="fa fa-car"></i>ทุน<span id="ContentPlaceHolder_cardOD3" class="pull-right">2,200,000</span></li>
                                                        <li><i class="fa fa-share-alt"></i>เสียหายส่วนแรก<span id="ContentPlaceHolder_cardODDD3" class="pull-right text-danger">-</span></li>
                                                    </ul>
                                                </div>
                                                <div class="pricing-box-footer">
                                                    <div class="row">
                                                        <div class="col-xs-4">
                                                            <input name="ctl00$ContentPlaceHolder$mc3_Compare" type="checkbox" id="ContentPlaceHolder_mc3_Compare" class="styled labelauty" value="VBI|วิริยะประกันภัย|VBI ป1 เก๋งห้าง (AS6) STD|ห้าง|53400|1,000,000|10,000,000|5,000,000|2,200,000|2,200,000|-|2,200,000|7|500,000|500,000|500,000|20161119212744_FY_144189|83|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87+%28AS6%29+STD&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=52095.54&amp;pack_pre=55965.86&amp;pack_offerprice=53400&amp;pack_offerdiscount=2565.86&amp;pack_id=957&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=83" style="display: none;"><label for="ContentPlaceHolder_mc3_Compare"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                                        </div>
                                                        <div class="col-xs-8">
                                                            <a href="#" class="btn btn-ar btn-default mar-l-10" data-toggle="modal" data-target="#modalCard3">ดูรายละเอียด</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="owl-controls">
                                <div class="owl-nav">
                                    <div class="owl-prev" style="display: none;">prev</div>
                                    <div class="owl-next" style="display: none;">next</div>
                                </div>
                                <div class="owl-dots" style="display: none;"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="modalCard1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                <h4 class="modal-title hideOverflow">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                            </div>
                            <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                <div class="title-style1">
                                    <img id="ContentPlaceHolder_mc1_INS" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/VIB.png">
                                    <p style="margin: 10px 0 0 0"><span id="ContentPlaceHolder_mc1_INSName">วิริยะประกันภัย</span></p>
                                    <h3 id="ContentPlaceHolder_mc1_PACKNAME" class="no-margin hideOverflow" style="color:hotpink">VBI ป1 เก๋งอู่ (S30)</h3>
                                    <div class="clearfix"></div>
                                </div>

                                <table class="table table-hover margin-top-20 table-cover">
                                    <tbody>
                                        <tr class="info">
                                            <th>ความคุ้มครองบุคคลภายนอก<span class="pull-right">วงเงิน (บาท)</span></th>
                                        </tr>
                                        <tr>
                                            <td>ชีวิต ร่างกาย หรืออนามัย<span id="ContentPlaceHolder_mc1_BI" class="pull-right">1,000,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ชีวิต ร่างกาย หรืออนามัย<span id="ContentPlaceHolder_mc1_BT" class="pull-right">10,000,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ทรัพย์สิน<span id="ContentPlaceHolder_mc1_TP" class="pull-right">5,000,000</span></td>
                                        </tr>
                                        <tr class="info">
                                            <th>ความคุ้มครองผู้เอาประกัน<span class="pull-right">วงเงิน (บาท)</span></th>
                                        </tr>
                                        <tr>
                                            <td>ความเสียหายต่อตัวรถยนต์<span id="ContentPlaceHolder_mc1_OD" class="pull-right em-primary">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>สูญหายหรือไฟไหม้<span id="ContentPlaceHolder_mc1_FIRE" class="pull-right em-primary">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ค่าความเสียหายส่วนแรก (Deduct)<span id="ContentPlaceHolder_mc1_ODDD" class="pull-right text-danger">-</span></td>
                                        </tr>
                                        <tr>
                                            <td>ประกันน้ำท่วม<span id="ContentPlaceHolder_mc1_FLOOD" class="pull-right">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>อุบัติเหตุส่วนบุคคล <span id="ContentPlaceHolder_mc1_P1">7</span><span id="ContentPlaceHolder_mc1_PA" class="pull-right">200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ค่ารักษาพยาบาล <span id="ContentPlaceHolder_mc1_P2">7</span><span id="ContentPlaceHolder_mc1_ME" class="pull-right">200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ประกันตัวผู้ขับขี่<span id="ContentPlaceHolder_mc1_BB" class="pull-right">200,000</span></td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <a id="ContentPlaceHolder_mc1_Package" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AD%E0%B8%B9%E0%B9%88+%28S30%29&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_netpre=47432.54&amp;pack_pre=50956.12&amp;pack_offerprice=48600&amp;pack_offerdiscount=2356.12&amp;pack_id=1834&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=289" target="_blank">ดูรายละเอียด</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="modalCard2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                <h4 class="modal-title hideOverflow">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                            </div>
                            <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                <div class="title-style1">
                                    <img id="ContentPlaceHolder_mc2_INS" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/VIB.png">
                                    <p style="margin: 10px 0 0 0"><span id="ContentPlaceHolder_mc2_INSName">วิริยะประกันภัย</span></p>
                                    <h3 id="ContentPlaceHolder_mc2_PACKNAME" class="no-margin hideOverflow">VBI ป1 เก๋งห้าง (AS6) STD</h3>
                                    <div class="clearfix"></div>
                                </div>

                                <table class="table table-hover margin-top-20 table-cover">
                                    <tbody>
                                        <tr class="info">
                                            <th>ความคุ้มครองบุคคลภายนอก<span class="pull-right">วงเงิน (บาท)</span></th>
                                        </tr>
                                        <tr>
                                            <td>ชีวิต ร่างกาย หรืออนามัย<span id="ContentPlaceHolder_mc2_BI" class="pull-right">1,000,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ชีวิต ร่างกาย หรืออนามัย<span id="ContentPlaceHolder_mc2_BT" class="pull-right">10,000,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ทรัพย์สิน<span id="ContentPlaceHolder_mc2_TP" class="pull-right">5,000,000</span></td>
                                        </tr>
                                        <tr class="info">
                                            <th>ความคุ้มครองผู้เอาประกัน<span class="pull-right">วงเงิน (บาท)</span></th>
                                        </tr>
                                        <tr>
                                            <td>ความเสียหายต่อตัวรถยนต์<span id="ContentPlaceHolder_mc2_OD" class="pull-right em-primary">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>สูญหายหรือไฟไหม้<span id="ContentPlaceHolder_mc2_FIRE" class="pull-right em-primary">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ค่าความเสียหายส่วนแรก (Deduct)<span id="ContentPlaceHolder_mc2_ODDD" class="pull-right text-danger">-</span></td>
                                        </tr>
                                        <tr>
                                            <td>ประกันน้ำท่วม<span id="ContentPlaceHolder_mc2_FLOOD" class="pull-right">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>อุบัติเหตุส่วนบุคคล <span id="ContentPlaceHolder_mc2_P1">7</span><span id="ContentPlaceHolder_mc2_PA" class="pull-right">500,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ค่ารักษาพยาบาล <span id="ContentPlaceHolder_mc2_P2">7</span><span id="ContentPlaceHolder_mc2_ME" class="pull-right">500,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ประกันตัวผู้ขับขี่<span id="ContentPlaceHolder_mc2_BB" class="pull-right">500,000</span></td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <a id="ContentPlaceHolder_mc2_Package" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87+%28AS6%29+STD&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=52095.54&amp;pack_pre=55965.86&amp;pack_offerprice=53400&amp;pack_offerdiscount=2565.86&amp;pack_id=957&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=83" target="_blank">ดูรายละเอียด</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="modalCard3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                <h4 class="modal-title hideOverflow">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                            </div>
                            <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                <div class="title-style1">
                                    <img id="ContentPlaceHolder_mc3_INS" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/VIB.png">
                                    <p style="margin: 10px 0 0 0"><span id="ContentPlaceHolder_mc3_INSName">วิริยะประกันภัย</span></p>
                                    <h3 id="ContentPlaceHolder_mc3_PACKNAME" class="no-margin hideOverflow">VBI ป1 เก๋งห้าง (AS6) STD</h3>
                                    <div class="clearfix"></div>
                                </div>

                                <table class="table table-hover margin-top-20 table-cover">
                                    <tbody>
                                        <tr class="info">
                                            <th>ความคุ้มครองบุคคลภายนอก<span class="pull-right">วงเงิน (บาท)</span></th>
                                        </tr>
                                        <tr>
                                            <td>ชีวิต ร่างกาย หรืออนามัย<span id="ContentPlaceHolder_mc3_BI" class="pull-right">1,000,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ชีวิต ร่างกาย หรืออนามัย<span id="ContentPlaceHolder_mc3_BT" class="pull-right">10,000,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ทรัพย์สิน<span id="ContentPlaceHolder_mc3_TP" class="pull-right">5,000,000</span></td>
                                        </tr>
                                        <tr class="info">
                                            <th>ความคุ้มครองผู้เอาประกัน<span class="pull-right">วงเงิน (บาท)</span></th>
                                        </tr>
                                        <tr>
                                            <td>ความเสียหายต่อตัวรถยนต์<span id="ContentPlaceHolder_mc3_OD" class="pull-right em-primary">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>สูญหายหรือไฟไหม้<span id="ContentPlaceHolder_mc3_FIRE" class="pull-right em-primary">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ค่าความเสียหายส่วนแรก (Deduct)<span id="ContentPlaceHolder_mc3_ODDD" class="pull-right text-danger">-</span></td>
                                        </tr>
                                        <tr>
                                            <td>ประกันน้ำท่วม<span id="ContentPlaceHolder_mc3_FLOOD" class="pull-right">2,200,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>อุบัติเหตุส่วนบุคคล <span id="ContentPlaceHolder_mc3_P1">7</span><span id="ContentPlaceHolder_mc3_PA" class="pull-right">500,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ค่ารักษาพยาบาล <span id="ContentPlaceHolder_mc3_P2">7</span><span id="ContentPlaceHolder_mc3_ME" class="pull-right">500,000</span></td>
                                        </tr>
                                        <tr>
                                            <td>ประกันตัวผู้ขับขี่<span id="ContentPlaceHolder_mc3_BB" class="pull-right">500,000</span></td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <a id="ContentPlaceHolder_mc3_Package" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87+%28AS6%29+STD&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=52095.54&amp;pack_pre=55965.86&amp;pack_offerprice=53400&amp;pack_offerdiscount=2565.86&amp;pack_id=957&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=83" target="_blank">ดูรายละเอียด</a>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="panel-group margin-top-10" id="accordion">

                    <div class="panel panel-default">
                        <div class="panel-heading panel-heading-link">

                            <a data-toggle="collapse" style="height: 50px;" data-parent="#accordion" href="#VBI" class="list-ins ">
                                <div class="col-xs-2 col-md-1 no-padding">
                                    <img id="ContentPlaceHolder_rptIns_Image2_0" class="img-responsive img-circle center-block" src="../logoCompany/VIB.jpg" style="max-width: 30px; background-color: white; margin-top: 5px;">
                                </div>
                                <div class="col-xs-10 col-md-6 hideOverflow no-padding">
                                    <span id="ContentPlaceHolder_rptIns_Label2_0">วิริยะประกันภัย</span>
                                </div>
                                <div class="col-xs-5 col-md-3 no-padding small">
                                    <span class="label label-success">ห้าง</span>
                                    <span id="ContentPlaceHolder_rptIns_Label1_0">53,400</span>
                                </div>
                                <div class="col-xs-4 col-md-2 no-padding small">
                                    <span class="label label-warning">อู่</span>
                                    <span id="ContentPlaceHolder_rptIns_Label3_0">48,600</span>
                                </div>
                            </a>

                        </div>


                        <div id="VBI" class="panel-collapse collapse in">
                            <div class="panel-body no-padding">
                                <div class="list-group">


                                    <div class="list-group-item">
                                        <div class="row">
                                            <div class="col-xs-1 no-padding">
                                                <input name="ctl00$ContentPlaceHolder$rptIns$ctl00$rptPackage$ctl00$ck" type="checkbox" id="ContentPlaceHolder_rptIns_rptPackage_0_ck_0" class="styled labelauty" value="VBI|วิริยะประกันภัย|VBI ป1 เก๋งห้าง (AS6) STD|ห้าง|53400|1,000,000|10,000,000|5,000,000|2,200,000|2,200,000|-|2,200,000|7|500,000|500,000|500,000|20161119212744_FY_144189|83|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87+%28AS6%29+STD&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=52095.54&amp;pack_pre=55965.86&amp;pack_offerprice=53400&amp;pack_offerdiscount=2565.86&amp;pack_id=957&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=83" style="display: none;"><label for="ContentPlaceHolder_rptIns_rptPackage_0_ck_0"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                            </div>
                                            <div class="col-xs-7 no-padding-right hideOverflow">
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_0_Label9_0" class="label label-success">ห้าง</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_0_Label5_0">VBI ป1 เก๋งห้าง (AS6) STD</span><br>
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_0_Label1_0" class="small">ทุน 2,200,000</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_0_Label2_0" class="small text-danger"></span>
                                            </div>
                                            <div class="col-xs-4 no-padding-left text-right">
                                                <s><span style="color: gray; font-size: 80%;">&nbsp;55,966&nbsp;</span></s><br>
                                                <a href="#" class="em-primary-inverse" data-toggle="modal" data-target="#2037-1"><i class="fa fa-shopping-cart"></i>&nbsp; 53,400</a>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="modal fade" id="2037-1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                                    <h4 class="modal-title hideOverflow" id="H1">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                                                </div>
                                                <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                                    <div class="title-style1">
                                                        <img id="ContentPlaceHolder_rptIns_rptPackage_0_imgINSCode_0" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/VIB.jpg">
                                                        <p style="margin: 10px 0 0 0">
                                                            วิริยะประกันภัย
                                                        </p>
                                                        <h3 class="no-margin hideOverflow">VBI ป1 เก๋งห้าง (AS6) STD (ซ่อมห้าง) </h3>
                                                        <div class="clearfix"></div>
                                                    </div>

                                                    <table class="table table-hover margin-top-20 table-cover">
                                                        <tbody>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองบุคคลภายนอก
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">1,000,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">10,000,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ทรัพย์สิน
																					<span class="pull-right">5,000,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองผู้เอาประกัน
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ความเสียหายต่อตัวรถยนต์
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>สูญหายหรือไฟไหม้
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่าความเสียหายส่วนแรก (Deduct)
																					<span class="pull-right text-danger">- <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันน้ำท่วม
																					<span class="pull-right">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>อุบัติเหตุส่วนบุคคล (7)
																					<span class="pull-right">500,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่ารักษาพยาบาล 7 ที่นั่ง
																					<span class="pull-right">500,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันตัวผู้ขับขี่
																					<span class="pull-right">500,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <a id="ContentPlaceHolder_rptIns_rptPackage_0_linkPackage_0" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87+%28AS6%29+STD&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=52095.54&amp;pack_pre=55965.86&amp;pack_offerprice=53400&amp;pack_offerdiscount=2565.86&amp;pack_id=957&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=83" target="_blank">ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="list-group-item">
                                        <div class="row">
                                            <div class="col-xs-1 no-padding">
                                                <input name="ctl00$ContentPlaceHolder$rptIns$ctl00$rptPackage$ctl01$ck" type="checkbox" id="ContentPlaceHolder_rptIns_rptPackage_0_ck_1" class="styled labelauty" value="VBI|วิริยะประกันภัย|VBI ป1 เก๋งอู่ (S30)|อู่|48600|1,000,000|10,000,000|5,000,000|2,200,000|2,200,000|-|2,200,000|7|200,000|200,000|200,000|20161119212744_FY_144189|289|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AD%E0%B8%B9%E0%B9%88+%28S30%29&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_netpre=47432.54&amp;pack_pre=50956.12&amp;pack_offerprice=48600&amp;pack_offerdiscount=2356.12&amp;pack_id=1834&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=289" style="display: none;"><label for="ContentPlaceHolder_rptIns_rptPackage_0_ck_1"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                            </div>
                                            <div class="col-xs-7 no-padding-right hideOverflow">
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_0_Label9_1" class="label label-warning">อู่</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_0_Label5_1">VBI ป1 เก๋งอู่ (S30)</span><br>
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_0_Label1_1" class="small">ทุน 2,200,000</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_0_Label2_1" class="small text-danger"></span>
                                            </div>
                                            <div class="col-xs-4 no-padding-left text-right">
                                                <s><span style="color: gray; font-size: 80%;">&nbsp;50,956&nbsp;</span></s><br>
                                                <a href="#" class="em-primary-inverse" data-toggle="modal" data-target="#2037-2"><i class="fa fa-shopping-cart"></i>&nbsp; 48,600</a>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="modal fade" id="2037-2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                                    <h4 class="modal-title hideOverflow" id="H2">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                                                </div>
                                                <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                                    <div class="title-style1">
                                                        <img id="ContentPlaceHolder_rptIns_rptPackage_0_imgINSCode_1" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/VIB.jpg">
                                                        <p style="margin: 10px 0 0 0">
                                                            วิริยะประกันภัย
                                                        </p>
                                                        <h3 class="no-margin hideOverflow">VBI ป1 เก๋งอู่ (S30) (ซ่อมอู่) </h3>
                                                        <div class="clearfix"></div>
                                                    </div>

                                                    <table class="table table-hover margin-top-20 table-cover">
                                                        <tbody>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองบุคคลภายนอก
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">1,000,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">10,000,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ทรัพย์สิน
																					<span class="pull-right">5,000,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองผู้เอาประกัน
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ความเสียหายต่อตัวรถยนต์
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>สูญหายหรือไฟไหม้
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่าความเสียหายส่วนแรก (Deduct)
																					<span class="pull-right text-danger">- <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันน้ำท่วม
																					<span class="pull-right">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>อุบัติเหตุส่วนบุคคล (7)
																					<span class="pull-right">200,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่ารักษาพยาบาล 7 ที่นั่ง
																					<span class="pull-right">200,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันตัวผู้ขับขี่
																					<span class="pull-right">200,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <a id="ContentPlaceHolder_rptIns_rptPackage_0_linkPackage_1" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=VBI&amp;pack_name=VBI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AD%E0%B8%B9%E0%B9%88+%28S30%29&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_netpre=47432.54&amp;pack_pre=50956.12&amp;pack_offerprice=48600&amp;pack_offerdiscount=2356.12&amp;pack_id=1834&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=289" target="_blank">ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading panel-heading-link">

                            <a data-toggle="collapse" style="height: 50px;" data-parent="#accordion" href="#SEI" class="list-ins collapsed">
                                <div class="col-xs-2 col-md-1 no-padding">
                                    <img id="ContentPlaceHolder_rptIns_Image2_1" class="img-responsive img-circle center-block" src="../logoCompany/SEI.jpg" style="max-width: 30px; background-color: white; margin-top: 5px;">
                                </div>
                                <div class="col-xs-10 col-md-6 hideOverflow no-padding">
                                    <span id="ContentPlaceHolder_rptIns_Label2_1">อาคเนย์ประกันภัย</span>
                                </div>
                                <div class="col-xs-5 col-md-3 no-padding small">
                                    <span class="label label-success">ห้าง</span>
                                    <span id="ContentPlaceHolder_rptIns_Label1_1">56,000</span>
                                </div>
                                <div class="col-xs-4 col-md-2 no-padding small">
                                    <span class="label label-warning">อู่</span>
                                    <span id="ContentPlaceHolder_rptIns_Label3_1">50,200</span>
                                </div>
                            </a>

                        </div>


                        <div id="SEI" class="panel-collapse collapse ">
                            <div class="panel-body no-padding">
                                <div class="list-group">


                                    <div class="list-group-item">
                                        <div class="row">
                                            <div class="col-xs-1 no-padding">
                                                <input name="ctl00$ContentPlaceHolder$rptIns$ctl01$rptPackage$ctl00$ck" type="checkbox" id="ContentPlaceHolder_rptIns_rptPackage_1_ck_0" class="styled labelauty" value="SEI|อาคเนย์ประกันภัย|SEI ป1 เก๋งห้าง|ห้าง|56000|1,000,000|10,000,000|2,500,000|2,200,000|2,200,000|-|2,200,000|5|100,000|100,000|300,000|20161119212744_FY_144189|84|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=SEI&amp;pack_name=SEI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=54630&amp;pack_pre=58688.43&amp;pack_offerprice=56000&amp;pack_offerdiscount=2688.43&amp;pack_id=490&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=84" style="display: none;"><label for="ContentPlaceHolder_rptIns_rptPackage_1_ck_0"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                            </div>
                                            <div class="col-xs-7 no-padding-right hideOverflow">
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_1_Label9_0" class="label label-success">ห้าง</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_1_Label5_0">SEI ป1 เก๋งห้าง</span><br>
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_1_Label1_0" class="small">ทุน 2,200,000</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_1_Label2_0" class="small text-danger"></span>
                                            </div>
                                            <div class="col-xs-4 no-padding-left text-right">
                                                <s><span style="color: gray; font-size: 80%;">&nbsp;58,688&nbsp;</span></s><br>
                                                <a href="#" class="em-primary-inverse" data-toggle="modal" data-target="#2079-1"><i class="fa fa-shopping-cart"></i>&nbsp; 56,000</a>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="modal fade" id="2079-1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                                    <h4 class="modal-title hideOverflow" id="H3">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                                                </div>
                                                <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                                    <div class="title-style1">
                                                        <img id="ContentPlaceHolder_rptIns_rptPackage_1_imgINSCode_0" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/SEI.jpg">
                                                        <p style="margin: 10px 0 0 0">
                                                            อาคเนย์ประกันภัย
                                                        </p>
                                                        <h3 class="no-margin hideOverflow">SEI ป1 เก๋งห้าง (ซ่อมห้าง) </h3>
                                                        <div class="clearfix"></div>
                                                    </div>

                                                    <table class="table table-hover margin-top-20 table-cover">
                                                        <tbody>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองบุคคลภายนอก
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">1,000,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">10,000,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ทรัพย์สิน
																					<span class="pull-right">2,500,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองผู้เอาประกัน
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ความเสียหายต่อตัวรถยนต์
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>สูญหายหรือไฟไหม้
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่าความเสียหายส่วนแรก (Deduct)
																					<span class="pull-right text-danger">- <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันน้ำท่วม
																					<span class="pull-right">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>อุบัติเหตุส่วนบุคคล (5)
																					<span class="pull-right">100,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่ารักษาพยาบาล 5 ที่นั่ง
																					<span class="pull-right">100,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันตัวผู้ขับขี่
																					<span class="pull-right">300,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <a id="ContentPlaceHolder_rptIns_rptPackage_1_linkPackage_0" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=SEI&amp;pack_name=SEI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AB%E0%B9%89%E0%B8%B2%E0%B8%87&amp;pack_netpre=54630&amp;pack_pre=58688.43&amp;pack_offerprice=56000&amp;pack_offerdiscount=2688.43&amp;pack_id=490&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=84" target="_blank">ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="list-group-item">
                                        <div class="row">
                                            <div class="col-xs-1 no-padding">
                                                <input name="ctl00$ContentPlaceHolder$rptIns$ctl01$rptPackage$ctl01$ck" type="checkbox" id="ContentPlaceHolder_rptIns_rptPackage_1_ck_1" class="styled labelauty" value="SEI|อาคเนย์ประกันภัย|SEI ป1 เก๋งอู่|อู่|50200|1,000,000|10,000,000|2,500,000|2,200,000|2,200,000|-|2,200,000|5|100,000|100,000|200,000|20161119212744_FY_144189|290|http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=SEI&amp;pack_name=SEI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_netpre=48977&amp;pack_pre=52615.11&amp;pack_offerprice=50200&amp;pack_offerdiscount=2415.11&amp;pack_id=488&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=290" style="display: none;"><label for="ContentPlaceHolder_rptIns_rptPackage_1_ck_1"><span class="labelauty-unchecked-image"></span><span class="labelauty-checked-image"></span></label>
                                            </div>
                                            <div class="col-xs-7 no-padding-right hideOverflow">
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_1_Label9_1" class="label label-warning">อู่</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_1_Label5_1">SEI ป1 เก๋งอู่</span><br>
                                                <span id="ContentPlaceHolder_rptIns_rptPackage_1_Label1_1" class="small">ทุน 2,200,000</span>&nbsp;
																<span id="ContentPlaceHolder_rptIns_rptPackage_1_Label2_1" class="small text-danger"></span>
                                            </div>
                                            <div class="col-xs-4 no-padding-left text-right">
                                                <s><span style="color: gray; font-size: 80%;">&nbsp;52,615&nbsp;</span></s><br>
                                                <a href="#" class="em-primary-inverse" data-toggle="modal" data-target="#2079-2"><i class="fa fa-shopping-cart"></i>&nbsp; 50,200</a>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="modal fade" id="2079-2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                                                    <h4 class="modal-title hideOverflow" id="H4">ประกันรถยนต์ ชั้น1 - AUDI A4 1.8cc 4 Door ปี2016</h4>
                                                </div>
                                                <div class="modal-body ativa-scroll" style="height: 286px; overflow-y: auto;">
                                                    <div class="title-style1">
                                                        <img id="ContentPlaceHolder_rptIns_rptPackage_1_imgINSCode_1" class="img-circle img-responsive icon-title pull-left" src="../logoCompany/SEI.jpg">
                                                        <p style="margin: 10px 0 0 0">
                                                            อาคเนย์ประกันภัย
                                                        </p>
                                                        <h3 class="no-margin hideOverflow">SEI ป1 เก๋งอู่ (ซ่อมอู่) </h3>
                                                        <div class="clearfix"></div>
                                                    </div>

                                                    <table class="table table-hover margin-top-20 table-cover">
                                                        <tbody>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองบุคคลภายนอก
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">1,000,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ชีวิต ร่างกาย หรืออนามัย
																					<span class="pull-right">10,000,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ทรัพย์สิน
																					<span class="pull-right">2,500,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="info">
                                                                <th>ความคุ้มครองผู้เอาประกัน
																					<span class="pull-right">วงเงิน (บาท)</span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <td>ความเสียหายต่อตัวรถยนต์
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>สูญหายหรือไฟไหม้
																					<span class="pull-right em-primary">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่าความเสียหายส่วนแรก (Deduct)
																					<span class="pull-right text-danger">- <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันน้ำท่วม
																					<span class="pull-right">2,200,000 <small>/ ครั้ง</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>อุบัติเหตุส่วนบุคคล (5)
																					<span class="pull-right">100,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ค่ารักษาพยาบาล 5 ที่นั่ง
																					<span class="pull-right">100,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>ประกันตัวผู้ขับขี่
																					<span class="pull-right">200,000 <small>/ คน</small></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <a id="ContentPlaceHolder_rptIns_rptPackage_1_linkPackage_1" class="btn btn-primary" href="http://www.xn--42cl3c6a8fucc8cwa.com/motorBuy.php?inscode=SEI&amp;pack_name=SEI+%E0%B8%9B1+%E0%B9%80%E0%B8%81%E0%B9%8B%E0%B8%87%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_od=2200000&amp;pack_fix=%E0%B8%AD%E0%B8%B9%E0%B9%88&amp;pack_netpre=48977&amp;pack_pre=52615.11&amp;pack_offerprice=50200&amp;pack_offerdiscount=2415.11&amp;pack_id=488&amp;car_brand=AUDI&amp;car_model=A4&amp;car_cc=1800&amp;car_year=2016&amp;car_code=110&amp;car_id=617&amp;afp_name=ancbroker2015&amp;ref1=20161119212744_FY_144189&amp;ref2=290" target="_blank">ดูรายละเอียด</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>
    <div id="back-top" style="display: none;">
        <a href="#header"><i class="fa fa-chevron-up"></i></a>
    </div>


</asp:Content>

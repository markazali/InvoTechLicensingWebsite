<%@ Page Language="vb" Title="Key Generator" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="KeyGen.aspx.vb" Inherits="InvoTechLicensingApp.KeyGen" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        div.grid {
            width: 100%;
        }

        select {
            direction: rtl;
        }
        
    </style>

        <script type="text/javascript">
        var datefield=document.createElement("input")
        datefield.setAttribute("type", "date")
 
        document.write('<link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />\n')
        document.write('<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"><\/script>\n')
        document.write('<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"><\/script>\n')

        </script>

        <script>
       
        //if (datefield.type!="date"){ //if browser doesn't support input type="date", initialize date picker widget:
        //    jQuery(function($){ //on document.ready
        //        $( "input[name$='txtExpire']").datepicker();
        //    })
        //}

        $(document).ready(function () {
            $("input[name$='txtExpire']").datepicker();
            var ckEmpbox = $('[id$="chkboxEmployeeLimit"]');
            var ckInvbox = $('[id$="chkboxInventoryLimit"]');
            var chSIStation = $('[id$="chkboxSelfIssueStation"]');
            var chSIPortal = $('[id$="chkboxSelfIssuePortal"]');
            var chWUPI = $('[id$="chkboxWhiteUpick"]');
            var chSRSAUDS = $('[id$="chkboxSRSConveyorAUDS"]');
            var chSRSCon = $('[id$="chkboxSRS"]');
            var chWCon = $('[id$="chkboxWhiteConveyor"]');
            var rdDisconnected = $('[id$="IsDisconnected"]');
            var rdConnected = $('[id$="IsConnected"]');
            var combosled = $('[id$="combosledLimit"]');
            var chHH = $('[id$="chkboxHandheld"]');
            var copied;

            chHH.change(function () {
                $('[id$="combosledLimit"]').attr("disabled",!($(this).is(":checked")))
            });
         

            $('#copy').click(function () {
                $('[id$="txtLicense"]').select();
                copied = document.execCommand('copy');
                window.getSelection().removeAllRanges();
            });


            rdConnected.change(function () {
                if (this.checked) {
                    $('[id$="TextBoxIP"]').val('');
                    $('[id$="TextBoxIP"]').attr('disabled', true);
                }
                else {
                    $('[id$="TextBoxIP"]').attr('disabled', false);
                }
            });

            rdDisconnected.change(function () {
                if (this.checked == false) {
                    $('[id$="TextBoxIP"]').val('');
                    $('[id$="TextBoxIP"]').attr('disabled', true);
                }
                else {
                    $('[id$="TextBoxIP"]').attr('disabled', false);
                }
            });

          

            ckEmpbox.change(function () {
                if (this.checked) {
                    ckInvbox.attr('checked', false);
                }
                
                clearLimit();

            });

            ckInvbox.change(function () {
                if (this.checked) {
                    ckEmpbox.attr('checked', false);
                }
                
                clearLimit();
                
            });

            chSIStation.change(function () {
                if (this.checked) {
                    chSIPortal.attr('checked', false);
                }
            });

            chSIPortal.change(function () {
                if (this.checked) {
                    chSIStation.attr('checked', false);
                }
            });
            
            chWUPI.change(function () {
                if (this.checked) {
                    chSRSAUDS.attr('checked', false);
                }
            });

            chSRSAUDS.change(function () {
                if (this.checked) {
                    chWUPI.attr('checked', false);
                }
            });
                
            chSRSCon.change(function () {
                if (this.checked) {
                    chWCon.attr('checked', false);
                }
            });

            chWCon.change(function () {
                if (this.checked) {
                    chSRSCon.attr('checked', false);
                }
            });

        });

        function clearLimit() {
            var ckEmpbox = $('[id$="chkboxEmployeeLimit"]');
            var ckInvbox = $('[id$="chkboxInventoryLimit"]');

            if (ckInvbox.attr("checked") == false && ckEmpbox.attr("checked") == false) {
                $('[id$=lblLimit]').text("Employee limit: ");
                $('[id$=DropDownListInvLimit]').css({ "display": "none" });
                $('[id$=DropDownListEmpLimit]').css({ "display": "" });
            }
        }

        function clearDropDown() {
            $('[id$=DropDownLimit]').empty();
        }

        function loadEmpOptions() {
            $('[id$=lblLimit]').text("Employee limit: ");

            $('[id$=DropDownListInvLimit]').css({ "display": "none" });
            $('[id$=DropDownListEmpLimit]').css({ "display": "" });
        }

        function loadInvOptions() {
            $('[id$=lblLimit]').text("Inventory limit: ");
           
            $('[id$=DropDownListInvLimit]').css({ "display": "" });
            $('[id$=DropDownListEmpLimit]').css({ "display": "none" });
        }

        function uncheckAll() {
            $("input:checkbox").attr('checked', false);
            $('[id$=txtMulti]').val('');
            $('[id$="txtLicense"]').val($.trim($('[id$="txtLicense"]').val()));
        }


        function ValidateIPaddress(ipaddress) {
            if (/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/.test(ipaddress)) {
                return (true)
            }
            alert("You have entered an invalid IP address!")
            return (false)
        }

        function validateForm() {
            
            if ($('[id$=IsDisconnected]').is(':checked')) {
                
                return ValidateIPaddress($('[id$=TextBoxIP]').val());
            }

            return true;
        }

    </script>

    <div class="grid">
        <div >
            <div style="height:10px;display:block;padding-left:5px; width:220px;">
            <label id="lblLimit" style="width:130px;display:inline-block;" runat="server">Employee limit: </label>
            <asp:DropDownList ID="DropDownListEmpLimit" runat="server" Width="80px" ></asp:DropDownList>
            <asp:DropDownList ID="DropDownListInvLimit" runat="server" Width="80px" ></asp:DropDownList>
            </div>
               

            <asp:CheckBox ID="chkboxHandheld" runat="server" Text="Handheld" /> # of sleds <asp:DropDownList ID="combosledLimit" runat="server" Width="80px" Enabled="False" ></asp:DropDownList>
            <br />
            <asp:CheckBox ID="chkboxHR" runat="server" Text="Human Resources" />
            <br />
            <asp:CheckBox ID="chkboxRFID" runat="server" Text="RFID Interface" />
            <br />
            <asp:CheckBox ID="chkboxMulti" runat="server" Text="Multi-Site" />&nbsp; <asp:TextBox runat="server" id="txtMulti" type="number"   min="1" max="64"/>
            <br />
            <asp:CheckBox ID="chkboxLaundryInterface" runat="server" Text="Landry Interface" />
            <br />
            <asp:CheckBox ID="chkboxCrown" runat="server" Text="Crown Laundry Interface" />
            <br />
            <asp:CheckBox ID="chkboxGIMSLaundry" runat="server" Text="GIMS Laundry Interface" />
            <br />
            <asp:CheckBox ID="chkboxExpires" runat="server" Text="Expiration Date" />&nbsp;<asp:TextBox runat="server"  placeholder="mm/dd/yyyy" id="txtExpire"  name="txtExpire"  maxlength="10" autocomplete="off"  Width="10em"/>
        </div>
        <div >
            <asp:CheckBox ID="chkboxWhiteUpick" runat="server" Text="White Conveyor U-Pick-It" />
            <br />
            <asp:CheckBox ID="chkboxPhoenix" runat="server" Text="Phoenix Conveyor" />
            <br />
            <asp:CheckBox ID="chkboxSRS" runat="server" Text="SRS Conveyor" />
            <br />
            <asp:CheckBox ID="chkboxWhiteConveyor" runat="server" Text="White Conveyor" />
            <br />
            <asp:CheckBox ID="chkboxAutoValet" runat="server" Text="Autovalet" />
            <br />
            <asp:CheckBox ID="chkboxHiemac" runat="server" Text="Hiemac Conveyor" />
            <br />
            <asp:CheckBox ID="chkboxSRSConveyorAUDS" runat="server" Text="SRS Conveyors AUDS" />
            <br />
            <asp:CheckBox ID="chkboxEventUniforms" runat="server" Text="Event Uniform ID" Enabled="False" />
            <br />
            <asp:CheckBox ID="chkboxITPasswords" runat="server" Text="IT Passwords" />
            <br />
            <asp:checkbox ID="chkboxMetalProgretti" runat="server" Text="Metal Progetti" />

        </div>
            <div >
       <asp:CheckBox ID="chkboxAccounting" runat="server" Text="Accounting" />
            <br />
            <asp:CheckBox ID="chkboxMMS" runat="server" Text="MMS" />
            <br />
                <asp:CheckBox ID="chkboxDemo" runat="server" Text="Demo" />
            <br />
                <asp:CheckBox ID="chkboxRestricted" runat="server" Text="Restricted Item Control" />
            <br />
                <asp:CheckBox ID="chkboxCoatcheck" runat="server" Text="White Conveyors Coatcheck" />
            <br />
                <asp:CheckBox ID="chkboxOneforOneScrubs" runat="server" Text="White Conveyors Issue By Size" />
            <br />
                <asp:CheckBox ID="chkboxWhiteBiometric" runat="server" Text="White Conveyors Biometric" />
            <br />
                <asp:CheckBox ID="chkboxWhiteSortingConveyorsConveyor" runat="server" Text="White Sorting Conveyor" />
            <br />
                  <asp:CheckBox ID="chkboxMPCommonEmployees" runat="server" Text="Multi-Property Common Employees" />
              
            <br />
               
        </div>

            <div >
        <asp:CheckBox ID="chkboxSelfIssueStation" runat="server" Text="Self-Issue Automated Station" />
            <br />
                <asp:CheckBox ID="chkboxSelfIssuePortal" runat="server" Text="Self-Issue Portal" />
            <br />
                <asp:CheckBox ID="chkboxInventoryLimit" runat="server" Text="Inventory Limit" onclick="loadInvOptions()" />
            <br />
                <asp:CheckBox ID="chkboxEmployeeLimit" runat="server" Text="Employee Assignment Limit" onclick="loadEmpOptions()" />
            <br />
                <asp:CheckBox ID="chkboxPolytex" runat="server" Text="Polytex Uniform Dispenser" />
                 <br />
                <asp:CheckBox ID="chkboxLaundryExport" runat="server" Text="Laundry Export" />
                 <br />
                <asp:CheckBox ID="chkboxCruiseCrewsExport" runat="server" Text="Cruise Crews Inactive" />
                <br />
                <asp:CheckBox ID="chkboxFornet" runat="server" Text="Fornet" />
                <br />
                <asp:CheckBox ID="chkboxACS" runat="server" Text="ACS Conveyor" />
                <br />
                
            <br />
        </div>
        
    </div>

    <div style="margin-top:10px;">Validation: <asp:RadioButton runat="server" id="IsConnected" Text="Connected" GroupName="licensevalidation" Checked="True" />&nbsp;&nbsp;&nbsp;<asp:RadioButton runat="server" id="IsDisconnected"  Text="Disconnected" GroupName="licensevalidation" />&nbsp;<asp:TextBox runat="server" id="TextBoxIP" name="txtIP"  Width="150px" MaxLength="15" Enabled="False"></asp:TextBox>
        
    </div>


    <div style="margin-top:10px;">License: <asp:TextBox runat="server" id="txtLicense" name="txtLicense"  Width="300px"></asp:TextBox>&nbsp;<input id="copy" name="copy" type="button" value="COPY"/>
        <asp:Label ID="LabelValidation" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="margin-top:10px;"><asp:Button runat="server" type="button" id="btnGenerate" name="btnGenerate"  Text="Generate License Key" Width="200px" CssClass="keybutton" OnClientClick="return validateForm()" />&nbsp;<asp:Button runat="server" type="button" id="btnValidate" name="btnValidate"  Text="Validate License Key" Width="200px"  OnClientClick="uncheckAll()" CssClass="keybutton"/></div>
    
</asp:Content>
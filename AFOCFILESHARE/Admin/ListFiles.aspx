<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListFiles.aspx.cs" Inherits="AFOCFILESHARE.Admin.ListFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">


<div class="row">
			<div class="col-lg-12">
				<h2 class="page-header">List Files</h2>
			</div>
		</div><!--/.row-->
				
		
		<div class="row">
			<div class="col-lg-12">
				<div class="panel panel-default">
				
					<div class="panel-body">
                   	 <form>
                	<span style="float:right; padding-right: 20px; margin-top:-5px; margin-bottom:10px;"> <asp:TextBox ID="txtsearch" runat="server" placeholder="Search"></asp:TextBox>
                        <asp:ImageButton ID="btnsearch" runat="server"    Width="18px" Height="18px" 
                            ImageUrl="~/Styles/css-admin/111.png" onclick="btnsearch_Click" > </asp:ImageButton></span>  </form>
						<table data-toggle="table"     data-select-item-name="toolbar1" data-pagination="true" data-sort-name="name" data-sort-order="asc">
						    <thead>
						    <tr>
						        <th data-sortable="false" >#</th>
						        <th data-sortable="true">Name</th>
						        <th  data-sortable="true">Type</th>
						        <th  data-sortable="true">Size(Kb)</th>
                                <th  data-sortable="true">Uploaded By</th>
                               <%-- <th >Download</th>--%>
                                <th >Export To PDF</th>
						    </tr>
						    </thead>
                             <tbody>
                             <%=getWhileLoopData()%>

                            </tbody>
						</table>
                        <script type="text/javascript">
                            $(function () {
                                $('#hover, #striped, #condensed').click(function () {
                                    var classes = 'table';

                                    if ($('#hover').prop('checked')) {
                                        classes += ' table-hover';
                                    }
                                    if ($('#condensed').prop('checked')) {
                                        classes += ' table-condensed';
                                    }
                                    $('#table-style').bootstrapTable('destroy')
						                .bootstrapTable({
						                    classes: classes,
						                    striped: $('#striped').prop('checked')
						                });
                                });
                            });

                            function rowStyle(row, index) {
                                var classes = ['active', 'success', 'info', 'warning', 'danger'];

                                if (index % 2 === 0 && index / 2 < classes.length) {
                                    return {
                                        classes: classes[index / 2]
                                    };
                                }
                                return {};
                            }
						</script>
					</div>
				</div>
			</div>
		</div><!--/.row-->	
                </div>
</asp:Content>

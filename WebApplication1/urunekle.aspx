<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urunekle.aspx.cs" Inherits="WebApplication1.urunekle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <link href="Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Scripts/css/style.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $("#Save").click(function () {
                var urun = new Object();
                urun.UrunAdi = $('#UrunAdi').val();
                urun.UrunFiyat = $('#UrunFiyat').val();
                urun.UrunDetay = $('#UrunDetay').val();
                urun.EklenmeTarihi = $('#EklenmeTarihi').val();
                urun.Stok = $('#Stok').val();
                urun.KategoriID = 1;
                urun.MarkaId = 1;
                
                $.ajax({
                    url: 'http://localhost:49970/api/Uruns',
                    type: 'POST',                    
                    dataType: 'json',
                    data: urun,
                    success: function (data) {
                        console.log(data);
                    },
                    error: function () {
                        console.log('Error in Operation');
                    }
                });
            });
        });
    </script>
</head>
<body>
    
    <div class="panel-body container">
        <h2 style="color:orangered">Ürün Ekleme Sayfasına Hoşgeldiniz</h2>
        <div class="adv-table editable-table " style="margin-top:50px">
      
        <div >     
            <div class="form-group">
                
                <div class="col-md-10" style="padding:10px">
                    <p>UrunAdi</p>
                    <input class="text-justify" type="text" name="UrunAdi" id="UrunAdi" />
                </div>
            </div>

            <div class="form-group">
                
                <div class="col-md-10" style="padding:10px">
                    <p>UrunFiyat</p>
                    <input type="text" name="UrunFiyat" id="UrunFiyat" />
                </div>
            </div>

            <div class="form-group">
                
                <div class="col-md-10" style="padding:10px">
                   <p>UrunDetay</p> 
                    <input type="text" name="UrunDetay" id="UrunDetay" />
                </div>
            </div>

            <div class="form-group">
                
                <div class="col-md-10" style="padding:10px">
                   <p>EklenmeTarihi</p> 
                    <input type="date" name="EklenmeTarihi" id="EklenmeTarihi" />
                </div>
            </div>

            <div class="form-group">
                
                <div class="col-md-10" style="padding:10px">
                    <p>Stok</p>
                    <input type="number" name="Stok" id="Stok" />
                    <div>
                 <input class="btn btn-success" style="margin-top:10px" type="button" id="Save" value="Save Data" />
           </div>
                </div>

            </div>
           
            
        </div>
            
            </div>
        </div>

</body>
</html>

function personel_ekle() {

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "100000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut",
        'body-output-type': 'trustedHtml'
      };

    let _name = document.getElementById("name").value
    let _surname = document.getElementById("surname").value
    let _department = document.getElementById("department").value

    if(_name==="" || _surname==="" || _department===""){
        toastr.error("Boş bilgi girilemez");
    }
    else{

        let _data = {
            name: _name,
            surname: _surname,
            department: _department,       
    }

        $.ajax({
            type:"POST",
            dataType:'json',
            contentType : 'application/json',
            url : "https://localhost:44332/api/Personel",
            data:JSON.stringify(_data),  
     
        }).done(function (data) {
         toastr.success("Kayıt Eklendi");
         personeltabloya_ekle();
         document.getElementById("name").value="";
         document.getElementById("surname").value="";
         document.getElementById("department").value="";
     });

    }
};

function personeltabloya_ekle(){
    $.ajax({
        type:"GET",
        dataType:'json',
        contentType:'application/json',
        url:"https://localhost:44332/api/Personel",
        success:function(result){
             if(result){
                 var row = '';
                 for(let i =0;i < result.length;i++){
                     row=row
                        + "<tr>"
                        + "<td>" + result[i].name + "</td>"
                        + "<td>" + result[i].surname + "</td>"
                        + "<td>" + result[i].department + "</td>"
                        + "<td> <button onclick='GetByPersonel(this.value)' value="+result[i].id+" data-bs-toggle='modal' data-bs-target='#exampleModal' class='btn btn-danger' type='button'><i class='fa fa-trash'></i> Silme</button>  <button class='btn btn-info' onclick='GetByPersonel(this.value)' value="+result[i].id+" data-bs-toggle='modal' data-bs-target='#exampleModalUpdate' ><i class='fa fa-edit'></i>Güncelleme</button></td>"
                        + "</tr>";
                    }
                if(row != ''){
                   document.getElementById("tblPersonelbody").innerHTML=row;
                }
             }
        },
    })
}

function personel_sil(id){
    $.ajax({
        type:"DELETE",
        dataType:'json',
        url:"https://localhost:44332/api/Personel?id="+id,
        contentType:'application/json', 
        complete: function (){
            toastr.success("Kayıt silindi.");
            document.getElementById("tblPersonelbody").innerHTML="";
            personeltabloya_ekle();
        }
    })
    
}

function GetByPersonel(id){

    $.ajax({
        type:"GET",
        dataType:'json',
        url:"https://localhost:44332/api/Personel/GetById/"+id,
        contentType:'application/json',
        success:function(response){
             for(let i=0;i<1;i++){
                 document.getElementById("delete").value=id;
                 document.getElementById("updateName").value = response.name;
                 document.getElementById("updateSurname").value = response.surname;
                 document.getElementById("updateDepartment").value = response.department; 
                 document.getElementById("update").value=id;                
             }    
        }
        
    }) 
    
}


function personel_update(id){

    let _nameupdate = document.getElementById("updateName").value
    let _surnameupdate = document.getElementById("updateSurname").value
    let _departmentupdate = document.getElementById("updateDepartment").value

    if(_nameupdate==="" || _surnameupdate==="" || _departmentupdate===""){
        toastr.error("Boş bilgi girilemez");
    }
    else{

        let _data = {
            id: parseInt(id),
            name: _nameupdate,
            surname: _surnameupdate,
            department: _departmentupdate,       
        }

        $.ajax({
            type:"PUT",
            dataType:'json',
            url:"https://localhost:44332/api/Personel",
            data:JSON.stringify(_data),  
            contentType:'application/json',
            complete: function (){
                toastr.success("Kayıt başarıyla güncellendi");
                document.getElementById("tblPersonelbody").innerHTML="";
                personeltabloya_ekle();
            }
        })  
    }
}

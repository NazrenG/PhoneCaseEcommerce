//// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.


//console.log("token");

//async function  temp() {
//    document.getElementById('loginForm').addEventListener('submit', function (e) {
//        console.log("token");
//        e.preventDefault();
//        const username = document.getElementById('username').value;
//        const password = document.getElementById('password').value;
//        try {
//            const response = await fetch('/Auth/LogIn', {
//                method: 'POST',
//                headers: {
//                    'Content-Type': 'application/json'
//                },
//                body: JSON.stringify({ username, password })
//            });
//            if (response.ok) {
//                const data = await response.text();
//                const token = data.token;

//                // Token'ı localStorage'e yaz
//                console.log("token");
//                localStorage.setItem('token', token);
//                console.log('Token kaydedildi:', token);

//                // Ana sehifeye yonelt
//                window.location.href = '/Home/Index';
//            } else {
//                console.log('Giriş başarısız');
//            }
//        }
//        catch (error) {
//            console.log('Giriş başarısız!');
//        }
//    })

//}


//temp()


//function readURL(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();
//        reader.onload = function (e) {
//            document.getElementById('profileImage').src = e.target.result;
//        };
//        reader.readAsDataURL(input.files[0]);
//    }
//}

//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

//var searchInp = document.getElementById("search");

//searchInp.addEventListener("keyup", function () {
//    var searchValue = searchInp.value;

//    var xhr = new XMLHttpRequest();

//    xhr.open("GET", `https://localhost:5001/Employee/Index?search=${searchValue}`);

//    xhr.send();

//    xhr.onreadystatechange = function () {
//        if (xhr.readyState == XMLHttpRequest.DONE) {
//            if (xhr.status == 200) {
//                document.getElementById("employeeList").innerHTML = xhr.responseText;
//            }
//            else {
//                alert('something else other than 200 was returned');
//            }
//        }
//    }
//})



// Get the search input element
//var searchInp = document.getElementById("search");

//// Attach an event listener for keyup event
//searchInp.addEventListener("keyup", function () {
//    var searchValue = searchInp.value;

//    var xhr = new XMLHttpRequest();

//    // Use a relative URL instead of hardcoding the full URL
//    // Also, append a timestamp to avoid caching issues
//    var url = `/Employee/Index?search=${encodeURIComponent(searchValue)}&t=${new Date().getTime()}`;

//    xhr.open("GET", url, true);

//    // Send the AJAX request
//    xhr.send();

//    // Handle the response
//    xhr.onreadystatechange = function () {
//        if (xhr.readyState === XMLHttpRequest.DONE) {
//            if (xhr.status === 200) {
//                // Update the employee list with the received data
//                document.getElementById("employeeList").innerHTML = xhr.responseText;
//            } else {
//                alert('Something went wrong! Status: ' + xhr.status);
//            }
//        }
//    };
//});


//var searchInp = document.getElementById("search");

//// Debounce function to avoid multiple requests on every key press
//function debounce(func, wait) {
//    let timeout;
//    return function (...args) {
//        clearTimeout(timeout);
//        timeout = setTimeout(() => func.apply(this, args), wait);
//    };
//}

//// Trigger AJAX request when the user types in the search box
//searchInp.addEventListener("keyup", debounce(function () {
//    var searchValue = searchInp.value;

//    var xhr = new XMLHttpRequest();
//    var url = `/Employee/Index?search=${encodeURIComponent(searchValue)}&t=${new Date().getTime()}`;

//    xhr.open("GET", url, true);
//    xhr.setRequestHeader("X-Requested-With", "XMLHttpRequest"); // Mark it as an AJAX request

//    xhr.onload = function () {
//        if (xhr.status === 200) {
//            // Update the employee list with the received data (just the <tr> rows)
//            document.getElementById("employeeList").innerHTML = xhr.responseText;
//        } else {
//            console.error("Error: " + xhr.status + " - " + xhr.statusText);
//        }
//    };

//    xhr.onerror = function () {
//        console.error("Request failed");
//    };

//    xhr.send();
//}, 300)); // 300ms debounce delay


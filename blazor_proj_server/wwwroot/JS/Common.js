window.showToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Great success!", { timeOut: 5000 });
    }
     
    if (type === "error") {
        toastr.error(message, "Uh ohs!", { timeOut: 5000 });
    }
}
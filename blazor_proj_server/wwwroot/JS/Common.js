window.showToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Great success!", { timeOut: 5000 });
    }
     
    if (type === "error") {
        toastr.error(message, "Uh ohs!", { timeOut: 5000 });
    }
}

window.showSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            "Great success!!",
            message,
            "success"
        )
    }
    if (type === "error") {
        Swal.fire(
            "Notification of your abject failure.",
            message,
            "error"
        )
    }
}
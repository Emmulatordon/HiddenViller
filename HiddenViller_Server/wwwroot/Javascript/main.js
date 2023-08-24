function local(message)
{
    alert(message)
}
window.myGlobal = function()
{
    alert("hello from global function")
}
function displayToast() {
    Swal.fire(
        'Good job!',
        'You clicked the button!',
        'success'
    )
}

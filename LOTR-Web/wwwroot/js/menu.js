const menuslide = document.querySelector(".menu-slide")
const navlinks = document.querySelector(".nav-links")

menuslide.addEventListener('click',()=>{
    navlinks.classList.toggle('mobile-menu')
})

function menutoggle() {
    const togglemenu = document.querySelector('.menu')
    togglemenu.classList.toggle('active')
}
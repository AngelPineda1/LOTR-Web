const menuslide = document.querySelector(".menu-slide")
const navlinks = document.querySelector(".nav-links")

menuslide.addEventListener('click',()=>{
    navlinks.classList.toggle('mobile-menu')
})
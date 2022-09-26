'use strict';

document.addEventListener('DOMContentLoaded', function () {

    // ------------------------------------------------------- //
    // Search Box
    // ------------------------------------------------------ //
    const navBar = document.querySelector('.navbar');
    const searchBtn = document.getElementById('search'),
          searchBox = document.querySelector('.search-box'),
          searchClose = document.querySelector('.dismiss');

    if (navBar) {
        searchBtn.addEventListener('click', (e) => {
            e.preventDefault();
            searchBox.classList.add('fadedIn');
        });

        searchClose.addEventListener('click', () => searchBox.classList.remove('fadedIn'));
    }



    // ------------------------------------------------------- //
    // Card Close
    // ------------------------------------------------------ //
    const closeCardBtn = document.querySelectorAll('.card-close a.remove');
    closeCardBtn.forEach((el) => {
        el.addEventListener('click', (e) => {
            e.preventDefault();
            el.closest('.card').style.opacity = '0';
            setTimeout(function () { el.closest('.card').classList.add('d-none'); }, 300);
        });
    });


    // ------------------------------------------------------- //
    // Card Close dropdown
    // ------------------------------------------------------ //
    const cardSettingsToggle = document.querySelectorAll('.card-close .dropdown-toggle');
    cardSettingsToggle.forEach((el) => {
        el.addEventListener('click', () => {
            if (el.classList.contains('show')) {
                setTimeout(function () { el.nextElementSibling.classList.add('is-visible'); }, 100);
            }
        });
    });

    document.addEventListener('click', function (e) {
        cardSettingsToggle.forEach((el) => {
            if (e.target == el) {
                setTimeout(function () { el.nextElementSibling.classList.add('is-visible'); }, 100);
            } else {
                el.nextElementSibling.classList.remove('is-visible');
            }
        });
    });





    // ------------------------------------------------------- //
    // Tooltips init
    // ------------------------------------------------------ //
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });



    // ------------------------------------------------------- //
    // Sidebar Functionality
    // ------------------------------------------------------ //
    const sbToggleBtn = document.getElementById('toggle-btn'),
          sideNavbar  = document.querySelector('.side-navbar'),
          innerContent = document.querySelector('.content-inner'),
          smBrand = document.querySelector('.navbar-header .brand-small'),
          lgBrand = document.querySelector('.navbar-header .brand-big');

    if (sideNavbar) {
        sbToggleBtn.addEventListener('click', function (e) {
            e.preventDefault();
            this.classList.toggle('active');

            sideNavbar.classList.toggle('shrinked');
            innerContent.classList.toggle('active');
            document.dispatchEvent(new Event('sidebarChanged'));

            /* THIS IS NOT THERE ANY MORE [UTILITY CLASSES USED] */

            // if (window.outerWidth > 1183) {
            //     if (sbToggleBtn.classList.contains('active')) {
            //         smBrand.style.display = 'none';
            //         lgBrand.style.display = 'block';
            //     } else {
            //         smBrand.style.display = 'block';
            //         lgBrand.style.display = 'none';
            //     }
            // }
            //
            // if (window.outerWidth < 1183) {
            //     smBrand.style.display = 'block';
            // }
        });
    }




    // ------------------------------------------------------- //
    // Footer
    // ------------------------------------------------------ //
    let footer = document.querySelector('#footer');
    if (footer) {
        document.addEventListener('sidebarChanged', function () {
            adjustFooter();
        });
        window.addEventListener('resize', function () {
            adjustFooter();
        });
    }

    function adjustFooter() {
        var footerBlockHeight = document.querySelector('#footer').outerHeight;
        innerContent.style.paddingBottom = `${footerBlockHeight}px`;
    }



    // ------------------------------------------------------- //
    // External links to new window
    // ------------------------------------------------------ //
    document.querySelectorAll('.external').forEach((el) => {
        el.addEventListener('click', function (e) {
            e.preventDefault();
            window.open(el.getAttribute('href'));
        });
    });


    // ------------------------------------------------------- //
    // Material Inputs
    // ------------------------------------------------------ //

    let materialInputs = document.querySelectorAll('input.input-material');
    let materialLabel = document.querySelectorAll('label.label-material');

    // activate labels for prefilled values
    let filledMaterialInputs = Array.from(materialInputs).filter(function (input) {
        return input.value !== '';
    });
    filledMaterialInputs.forEach(input => input.parentElement.lastElementChild.setAttribute('class', 'label-material active'));

    // move label on focus
    materialInputs.forEach((input) => {
        input.addEventListener('focus', function () {
            input.parentElement.lastElementChild.setAttribute('class', 'label-material active');
        });
    });

    // remove/keep label on blur
    materialInputs.forEach((input) => {
        input.addEventListener('blur', function () {
            if (input.value !== '') {
                input.parentElement.lastElementChild.setAttribute('class', 'label-material active');
            } else {
                input.parentElement.lastElementChild.setAttribute('class', 'label-material');
            }
        });
    });


    function bsValidationBehavior(errorInputs, form) {
        function watchError() {
            errorInputs.forEach((input) => {
                if (input.classList.contains('js-validate-error-field')) {
                    input.classList.add('is-invalid');
                    input.classList.remove('is-valid');
                } else {
                    input.classList.remove('is-invalid');
                    input.classList.add('is-valid');
                }
            });
        }
        watchError();
    }

    // ------------------------------------------------------- //
    // Login Form Validation
    // ------------------------------------------------------ //
    let loginForm = document.querySelector('.login-form');
    if (loginForm) {
        new window.JustValidate('.login-form', {
            rules: {
                loginUsername: {
                    required: true,
                    email: true
                },
                loginPassword: {
                    required: true,
                },
                Fullname: {
                    required: true,
                },
                Gender: {
                    required: true,
                },
                DateOfBirth: {
                    required: true,
                },
                PhoneNumber: {
                    required: true,
                },
                Address: {
                    required: true,
                },
                BloodType: {
                    required: true,
                },
                Height: {
                    required: true,
                },
                Weight: {
                    required: true,
                },
                History: {
                    required: true,
                },
                Symptoms: {
                    required: true,
                },
                LabOrder: {
                    required: true,
                },
                Checkup: {
                    required: true,
                },
                Diagnosis: {
                    required: true,
                },
                DrugName: {
                    required: true,
                },
                DrugType: {
                    required: true,
                },
                Dosage: {
                    required: true,
                },
                howLong: {
                    required: true,
                },
                Advice: {
                    required: true,
                },
                PhysicianName: {
                    required: true,
                },
                Date: {
                    required: true,
                },
                DrugPrice: {
                    required: true,
                },
                DrugTradeName: {
                    required: true,
                },
                DrugGenericName: {
                    required: true,
                },
                Note: {
                    required: true,
                },
                ExpirationDate: {
                    required: true,
                },
                Role: {
                    required: true,
                },
                RememberToken: {
                    required: true,
                },
                labResult: {
                    required: true,
                },
                id: {
                    required : true,
                }
            },
            messages: {
                loginUsername: 'Please enter a valid email',
                loginPassword: 'Please enter your password',
                Fullname: 'Please enter your full name',
                Gender: 'Please enter your gender',
                DateOfBirth: 'Please enter a valid Date of Birth',
                PhoneNumber: 'Please enter a valid phone number',
                Address: 'Please enter a valid address',
                BloodType: 'Please enter a valid blood type',
                Height: 'Please enter a valid height',
                Weight: 'Please enter a valid email',
                History: 'Please enter a valid history',
                Symptoms: 'Please enter a valid symptoms',
                LabOrder: 'Please enter a lab order',
                Checkup: 'Please enter a valid check up',
                Diagnosis: 'Please enter a valid diagnosis',
                DrugName: 'Please enter a valid drug name',
                DrugType: 'Please enter a valid drug type',
                Dosage: 'Please enter a dosage',
                howLong: 'Please enter a how long a medicine should be taken',
                Advice: 'Please enter an advice',
                PhysicianName: 'Please enter a physician name',
                Date: 'Please enter a date',
                DrugPrice: 'Please enter a drug price',
                DrugTradeName: 'Please enter a drug trade name',
                DrugGenericName: 'Please enter a drug generic name',
                Note: 'Please enter a note',
                ExpirationDate: 'Please enter an expiration date',
                Role: 'Please enter a role',
                RememberToken: 'Please enter a remember token',
                labResult: 'Please enter a lab result'
                id : "Please enter a patient ID"
            },
            invalidFormCallback: function () {
                let errorInputs = document.querySelectorAll('.login-form input[required]');
                bsValidationBehavior(errorInputs, loginForm);
                loginForm.addEventListener('keyup', () => bsValidationBehavior(errorInputs, loginForm))
            },
        });
    }


    // ------------------------------------------------------- //
    // Register Form Validation
    // ------------------------------------------------------ //
    let registerForm = document.querySelector('.register-form');
    if (registerForm) {
        new window.JustValidate('.register-form', {
            rules: {
                registerUsername: {
                    required: true
                },
                registerEmail: {
                    required: true,
                    email: true
                },
                registerPassword: {
                    required: true,
                },
                registerAgree: {
                    required: true,
                },
            },
            messages: {
                registerUsername: 'Please enter your username',
                registerEmail: 'Please enter a valid email address',
                registerPassword: 'Please enter your password',
                registerAgree: 'Your agreement is required'
            },
            invalidFormCallback: function () {
                let errorInputs = document.querySelectorAll('.register-form input[required]');
                bsValidationBehavior(errorInputs, registerForm);
                registerForm.addEventListener('keyup', () => bsValidationBehavior(errorInputs, registerForm))
                registerForm.addEventListener('change', () => bsValidationBehavior(errorInputs, registerForm))
            },
        });
    }


    // ------------------------------------------------------- //
    // Profile page choices
    // ------------------------------------------------------ //
    function injectClassess(x) {
        let pickerCustomClass = x.dataset.customclass;
        let pickerSevClasses = pickerCustomClass.split(' ');
        x.parentElement.classList.add.apply(x.parentElement.classList, pickerSevClasses);
    }

    const profileCountryChoices = document.querySelector('.profile-country-choices');
    if (profileCountryChoices) {
        const countryChoices = new Choices(profileCountryChoices, {
            searchEnabled: false,
            placeholder: false,
            callbackOnInit: () => injectClassess(profileCountryChoices)
        });
    }


});

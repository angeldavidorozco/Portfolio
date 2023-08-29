/*!
    * Start Bootstrap - SB Admin v7.0.7 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2023 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    const targetElement = document.querySelector('#layoutSidenav_content');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        //if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
            //document.body.classList.add('sb-sidenav-toggled');
        //}
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }


});

function toggleFlip(card) {
    card.querySelector('.flip-card-inner').classList.toggle('flipped');
}
// Toggle the side navigation


function toggleFixedContainer() {
    var mainContainer = document.getElementById("MainContainer");
    var fixedContainer = document.getElementById("fixedContainer");
    var fixedContainerBlank = document.getElementById("fixed-container-blank");


    // Toggle the right position of the fixed container
    if (fixedContainer.style.right === "-300px") {
        fixedContainer.style.right = "0";
       
        
    }
    else {
        fixedContainer.style.right = "-300px";
        
    }

    $(".jumbotron").toggleClass("jumbotron-margin");
}


//Script for handling the AJAX request

/*
$(document).ready(function () {
    $("#filterInput").typeahead({
        source: function (query, result) {
            $.ajax({
                url: "/Home/SearchQuery",
                type: "GET",
                data: { filter: query },
                //dataType: "json", // Expecting JSON data as the response
                success: function (data) {
                    // Handle the JSON data here
                    console.log(data); // Display the JSON data in the browser console

                    // Pass the data to the typeahead plugin
                    result(data);
                },
                error: function (xhr, status, error) {
                    // Handle error if the request fails
                    console.error(error);
                }
            });
        },
        displayText: function (item) {
            // Customize the display of each item in the dropdown
            return item.Descrip;
        }
    });
});
*/


/*
$(document).ready(function () {
    $("#filterInput").on("keyup", function () {

        let resultList = [];

        $.ajax({
            url: "/Home/SearchQuery", // Replace with the actual controller and action that retrieves the filtered data
            type: "GET",
            dataType: 'json',
            success: function (json) {
                let arrayLength = json.length;
                for (let i = 0; i < arrayLength; i++)
                {
                    if (!resultList.includes(json['Descrip'][i])) 
                    {
                        resultList.push(json['Descrip'][i]);
                    }
                
                }

                return resultList;
            }
        });

        $("#filterInput").typeahead(
        {
            name: 'Descripts',
            source: resultList
        });

    });
});

//typeahead configuration
$(document).ready(function () {

    
    $("#filterInput").on("click", function () {
        ev = $.Event("keydown");
        ev.keyCode = ev.which = 40;
        $("#filterInput").trigger(ev);
        return true;
    });

    $('#filterInput').typeahead({

        source: function (filter, process) {
            return $.getJSON(
                'Home/SearchQuery',
                { query: filter },
                function (data) {
                    return process(data.map((x => x.descrip)));
                });
        },
        minLength: 0
    

    });

});
*/

$(document).ready(function () {


    /////////////////////////////////////
    //
    // Base selection and search call
    //
    /////////////////////////////////////

    var selectedNameValue = "";

    // Cache the second dropdown element to improve performance
    var Dropdown = $("#DescripDropdown");

    $("#baseContainer").attr("src", "/lib/images/provisory_icon.jpg");
    $("#extraContainer").attr("src", "/lib/images/provisory_icon.jpg");

    // Listen for changes on the first dropdown
    $("#BaseDropdown").on("change", function () {
        // Get the selected value from the first dropdown
       
        selectedNameValue = $(this).val();

        ClearAll();

        updatePF();
        
        // Enable or disable the target dropdown based on the selected value
        if (selectedNameValue === '') {

            Dropdown.val("");
            Dropdown.prop('disabled', true);

            /*$("#AnimeDropdown").val("");
            $("#ImageDropdown").val("");*/
            ClearAll();
            $("#AnimeDropdown").prop('disabled', true);
            $("#baseContainer").attr("src", "/lib/images/provisory_icon.jpg");
            $("#baseDisplay").attr("src", "/lib/images/provisory_icon.jpg");

            
        } else {
            Dropdown.prop('disabled', false);

            AjaxBase(selectedNameValue);


        }

    });

    // Trigger the change event on page load to set the initial state
    $("#BaseDropdown").trigger("change");
    $("#DescripDropdown").trigger("change");
  
    var selectedDecripValue = "";
    
    Dropdown.on("change", function () {

        $("#AnimeDropdown").val("");
        $("#ImageDropdown").val("");
        $("#imageDisplay").attr("src", "/lib/images/provisory_icon.jpg");
        $("#imageContainer").attr("src", "/lib/images/provisory_icon.jpg");
        $("#ImageDropdown").prop("disabled", true);

        updatePF();
        
        //const selectedValue = $("#ImageDropdown").val();
        selectedDecripValue = $(this).find("option:selected").text();
        selectedPathValue = $(this).val();
        // Update the image source based on the selected value
        // Replace 'path/to/images/' with the actual path to your images
        if (Dropdown.val() === "") {
            $("#baseDisplay").attr("src", "/lib/images/provisory_icon.jpg");
            $("#baseContainer").attr("src", "/lib/images/provisory_icon.jpg");


            $("#AnimeDropdown").val("");
            $("#ImageDropdown").val("");
            $("#AnimeDropdown").prop("disabled", true);
        }
        else {
            AjaxAnime(selectedDecripValue);
            
            $("#baseContainer").show()
            $("#baseContainer").attr("src", "/lib/" + selectedPathValue + ".jpg");
            $("#baseDisplay").attr("src", "/lib/" + selectedPathValue + ".jpg");
            

            $("#AnimeDropdown").prop("disabled", false);

        }

    });


    /////////////////////////////////////
    //
    // Image selection and search call
    //
    /////////////////////////////////////



    // Cache the second dropdown element to improve performance
    const $imageDropdown = $("#ImageDropdown");

    // Listen for changes on the first dropdown
    $("#AnimeDropdown").on("change", function () {
       
        // Get the selected value from the first dropdown
        const selectedAnimeValue = $(this).val();
        
        // Enable or disable the target dropdown based on the selected value
        if (selectedAnimeValue === '') {
            $imageDropdown.prop('disabled', true);
        } else
        {
            $imageDropdown.prop('disabled', false);

            AjaxImage(selectedAnimeValue, selectedDecripValue);
            
        } 

    });

    // Trigger the change event on page load to set the initial state
    $("#AnimeDropdown").trigger("change");

    

    $("#ImageDropdown").on("change", function () {
        updatePF();
        // Get the selected value from the select element
        const selectedValue = $("#ImageDropdown").val();

        // Update the image source based on the selected value
        // Replace 'path/to/images/' with the actual path to your images
        if ($("#ImageDropdown").val() === "") {
            $("#imageDisplay").attr("src", "/lib/images/provisory_icon.jpg");
            $("#imageContainer").attr("src", "/lib/images/provisory_icon.jpg");
        }
        else {
            console.log(selectedValue);
            $("#imageDisplay").attr("src", "/lib/" + selectedValue + ".jpg");
            
            $("#imageContainer").attr("src", "/lib/" + selectedValue + ".jpg");

        }

    });
    $("#ImageDropdown").trigger("change");
    
});
/*
$(document).ready(function () {

    $("#ImageDropdown").prop("disabled", true);
    $("#ExtraDropdown").prop("disabled", true);
    

    // Get references to the select and image elements
    const $basePath = $("#BaseDropdown");
    const $baseDisplay = $("#baseDisplay");
    $("#baseContainer").hide()
    // Listen for the change event on the select element
    $basePath.on("change", function () {
        // Get the selected value from the select element
        const selectedValue = $imagePath.val();

        // Update the image source based on the selected value
        // Replace 'path/to/images/' with the actual path to your images
        if ($basePath.val() === "") {
            $baseDisplay.attr("src", "/lib/images/provisory_icon.jpg");
            $("#baseContainer").hide()


            $("#AnimeDropdown").prop("disabled", true);
        }
        else {
            $baseDisplay.attr("src", "/lib/" + selectedValue + ".jpg");
            $("#baseContainer").show()
            $("#baseContainer").attr("src", "/lib/" + selectedValue + ".jpg");


            $("#AnimeDropdown").prop("disabled", false); 

        }

    });



    // Get references to the select and image elements
    const $imagePath = $("#ImageDropdown");
    const $imageDisplay = $("#imageDisplay");
    $("#imageContainer").hide()
    // Listen for the change event on the select element
    $imagePath.on("change", function () {
        // Get the selected value from the select element
        const selectedValue = $imagePath.val();

        // Update the image source based on the selected value
        // Replace 'path/to/images/' with the actual path to your images
        if ($imagePath.val() === "") {
            $imageDisplay.attr("src", "/lib/images/provisory_icon.jpg");
            $("#imageContainer").hide()
        }
        else { 
            $imageDisplay.attr("src", "/lib/" + selectedValue + ".jpg");
            $("#imageContainer").show()
            $("#imageContainer").attr("src", "/lib/" + selectedValue + ".jpg");

        }
        
    });

    // Get references to the select and image elements
    const $ExtraPath = $("#ExtraDropdown");
    const $ExtraDisplay = $("#ExtraDisplay");
    $("#extraContainer").hide()

    // Listen for the change event on the select element
    $ExtraPath.on("change", function () {
        // Get the selected value from the select element
        const selectedValue = $ExtraPath.val();

        // Update the image source based on the selected value
        // Replace 'path/to/images/' with the actual path to your images
        if ($ExtraPath.val() === "") {
            $ExtraDisplay.attr("src", "/lib/images/provisory_icon.jpg");
            $("#extraContainer").hide()
        }
        else {
            $ExtraDisplay.attr("src", "/lib/" + selectedValue + ".jpg");
            $imageDisplay.attr("src", "/lib/" + selectedValue + ".jpg");
            $("#extraContainer").show()
            $("#extraContainer").attr("src", "/lib/" + selectedValue + ".jpg");
        }

    });
});
*/

var selectedColor = $("#ColorSelector").val();
var selected_Color = $("#Color-Selector").val();
var midColor = $("#MidSelector").val();
var numberSelected = $("#Color").val();
var direction = "to bottom"


$("#225deg").on("click", function () {
    direction = "225deg";
    $("#Color").trigger("change");
    $("#ColorSelector").trigger("input");
});
$("#135deg").on("click", function () {
    direction = "135deg";

    $("#Color").trigger("change");
    $("#ColorSelector").trigger("input");
});

$("#toBottom").on("click", function () {
    direction = "to bottom";
    $("#Color").trigger("change");
    $("#ColorSelector").trigger("input");
});

$("#toLeft").on("click", function () {
    direction = "to left";
    $("#Color").trigger("change");
    $("#ColorSelector").trigger("input");
});

$("#toRight").on("click", function () {
    direction = "to right";
    $("#Color").trigger("change");
    $("#ColorSelector").trigger("input");
});

$(document).ready(function () {

    
    $("#Color").on('change', function () {

        numberSelected = $(this).val();
        

        switch (numberSelected) {
            case "1 Color":
                // Code to execute if expression matches value1
                
                $("#Mid, #Bot").hide();

                $("#ColorSelector").on('input', function () {
                    selectedColor = $(this).val()
                    $("#ColorMixer").css("background", selectedColor);
                    $("#colorContainer").css("background", selectedColor);
                    updatePF();

                });

                break;

            case "2 Colores":
                // Code to execute if expression matches value2
                
                $("#Mid").hide();
                $("#Bot").show();
                
               $("#ColorSelector").on('input', function () {
                    selectedColor = $(this).val()
                    $("#ColorMixer").css("background", "linear-gradient("+direction+", " + selectedColor + " , " + selected_Color + ")");
                   $("#colorContainer").css("background", "linear-gradient(" + direction + ", " + selectedColor + " , " + selected_Color + ")");
                   updatePF();
                });
                $("#Color-Selector").on('input', function () {
                    selected_Color = $(this).val()
                    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + " , " + selected_Color + ")");
                    $("#colorContainer").css("background", "linear-gradient(" + direction + ", " + selectedColor + " , " + selected_Color + ")");
                    updatePF();
                });

                break;

            case "3 Colores":
                
                $("#Mid, #Bot").show();

                $("#ColorSelector").on('input', function () {
                    // Get the value chosen from the color input
                    selectedColor = $(this).val();


                    // Do something with the selected color
                    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
                    $("#colorContainer").css("background", "linear-gradient(" + direction + ", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
                    updatePF();
                });

                $("#Color-Selector").on('input', function () {
                    // Get the value chosen from the color input
                    selected_Color = $(this).val();

                    // Do something with the selected color
                    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + ", " + midColor + " , " + selected_Color + ")");
                    $("#colorContainer").css("background", "linear-gradient(" + direction + ", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
                    updatePF();
                });

                $("#MidSelector").on('input', function () {
                    // Get the value chosen from the color input
                    midColor = $(this).val();

                    // Do something with the selected color
                    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + ", " + midColor + " , " + selected_Color + ")");
                    $("#colorContainer").css("background", "linear-gradient(" + direction + ", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
                    updatePF();
                });


                break;

            // You can have more cases as needed
        }
    });

    $("#Color").trigger("change");


});



/*
// Add a click event listener to the input
$("#ColorSelector").on('input', function () {
    // Get the value chosen from the color input
    selectedColor = $(this).val();


    // Do something with the selected color
    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
    $("#colorContainer").css("background", "linear-gradient(" + direction +", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
});

$("#Color-Selector").on('input', function () {
    // Get the value chosen from the color input
    selected_Color = $(this).val();

    // Do something with the selected color
    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + ", " + midColor + " , " + selected_Color + ")");
    $("#colorContainer").css("background", "linear-gradient(" + direction +", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
});

$("#MidSelector").on('input', function () {
    // Get the value chosen from the color input
    midColor = $(this).val();

    // Do something with the selected color
    $("#ColorMixer").css("background", "linear-gradient(" + direction +", " + selectedColor + ", " + midColor + " , " + selected_Color + ")");
    $("#colorContainer").css("background", "linear-gradient(" + direction +", " + selectedColor + " , " + midColor + " , " + selected_Color + ")");
});*/


//ajax request for the images
function AjaxImage(Anime, baseDescrip)
{
    // Get a reference to the select element
    var selectElement = $("#ImageDropdown");
    var arg = Anime;

    // Make the AJAX request
    $.ajax({
        url: "/Home/ImageQuery", // Replace with your controller and action URL
        type: "GET",
        data: { arg: arg },
        dataType: "json",
        success: function (data) {
            
            selectElement.empty();

            // Add a default option if needed
            selectElement.append($("<option>").val("").text("Seleccione una imagen"));

            // Process the data received from the server
            $.each(data, function (index, item) {

                if (item.imageBase === baseDescrip) {
                    // Add each item as an option to the select element
                    selectElement.append($("<option>").val(item.imagePath).text(item.imageID));
                }
            });
        },
        error: function (xhr, status, error) {
            // Handle error if the request fails
            console.error(error);
        }
    });
}

function AjaxBase(BaseType) {
    // Get a reference to the select element
    var selectElement = $("#DescripDropdown");
    var arg = BaseType;

    // Make the AJAX request
    $.ajax({
        url: "/Home/BaseQuery", // Replace with your controller and action URL
        type: "GET",
        data: { arg: arg },
        dataType: "json",
        success: function (data) {

           
            selectElement.empty();
           

            // Add a default option if needed
            selectElement.append($("<option>").val("").text("Seleccione una base"));
           

            $.each(data, function (index, item) {
                
                selectElement.append($("<option>").val(item.basePath).text(item.descrip));

            });


        },
        error: function (xhr, status, error) {
            // Handle error if the request fails
            console.error(error);
        }
    });
}

function AjaxAnime(descrip) {
    // Get a reference to the select element
    
    var arg = descrip;

    // Make the AJAX request
    $.ajax({
        url: "/Home/AnimeQuery", // Replace with your controller and action URL
        type: "GET",
        data: { arg: arg },
        dataType: "json",
        success: function (data) {

            $("#AnimeDropdown").empty();

            // Add a default option if needed
            $("#AnimeDropdown").append($("<option>").val("").text("Seleccione un Anime"));

            // Process the data received from the server
            $.each(data, function (index, item) {

               
                    // Add each item as an option to the select element
                $("#AnimeDropdown").append($("<option>").val(item.imageType).text(item.imageType));
                
            });
        },
        error: function (xhr, status, error) {
            // Handle error if the request fails
            console.error(error);
        }
    });
}

$("#Send").on("click", function () {


    
    const phoneNumber = "5493512125140"; // Replace with the actual phone number
    const message = encodeURIComponent($("#PF").text());
    const whatsappLink = `https://api.whatsapp.com/send?phone=${phoneNumber}&text=${message}`;

    window.open(whatsappLink, "_blank");

});

function ClearAll()
{

    $("#AnimeDropdown").val("");
    $("#ImageDropdown").val("");
    $("#imageDisplay").attr("src", "/lib/images/provisory_icon.jpg");
    $("#ImageDropdown").prop('disabled', true);

}

$("#ScrollImage").on("click", function () {
    $("html, body").animate({ scrollTop: $("#ImageSection").offset().top }, "slow");
});

$("#ScrollContact").on("click", function () {
    $("html, body").animate({ scrollTop: $("#ContactSection").offset().top }, "slow");
});

$("#ScrollColor").on("click", function () {
    $("html, body").animate({ scrollTop: $("#ColorSection").offset().top }, "slow");
});
$("#ScrollBase").on("click", function () {
    $("html, body").animate({ scrollTop: $("#BaseSection").offset().top }, "slow");
});
$("#ScrollAyuda").on("click", function () {
    $("html, body").animate({ scrollTop: $("#AyudaSection").offset().top }, "slow");
});
$("#ScrollExtra").on("click", function () {
    $("html, body").animate({ scrollTop: $("#ExtraSection").offset().top }, "slow");
});

function updatePF() {
    // Get the values from each form's input fields
    var PFBaseName = $("#BaseDropdown").val();
    var PFBaseType = $("#DescripDropdown").find("option:selected").text();;
    var PFImage = $("#ImageDropdown").find("option:selected").text();;
    var Color = $("#ColorMixer").css("background");
    var PFExtra = $("#BaseDropdown").val();

    
    var PFColor = Color.match(/linear-gradient\([^]+\)/);

    var descrip = $("#messageInput").text();

    // Construct the final string as per your desired format
    const finalString = `Hola! personalice mi producto usando la pagina web de Resin Otaku. Mi producto es:\n
    Base: ${PFBaseName}\n 
    Tipo: ${PFBaseType}\n 
    Imagen: ${PFImage}\n 
    Color: ${PFColor[0]}\n 
    Extra: ${PFExtra}\n 
    Ademas, quiero comentar:\n 
    ${descrip}`;

    // Update the content of the result div with the final string
    document.getElementById("PF").textContent = finalString;
}


/*
@{
    string oldType2 = "";
}
@foreach(var imageOption in ViewBag.ImageTable)
{
                        string newType = imageOption.ImageType;


    if (newType != oldType2) {
        <option value="@imageOption.ImageType">@imageOption.ImageType</option>
        oldType2 = newType;
    }

}
*/


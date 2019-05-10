
function RegisterImage(img)
{
    switch (img)
    {
        case "Knight":
            var aranaktu = document.getElementById('1');
            aranaktu.src = "../Images/Knight_Placeholder.png";
            break;
        case "Huntress":
            var aranaktu = document.getElementById('1');
            aranaktu.src = "../Images/Huntress_Placeholder.png";
            break;
        case "Spooky":
            var aranaktu = document.getElementById('1');
            aranaktu.src = "../Images/Spooky_Placeholder.png";
            break;
    }
}

function UserImage()
{
    ImgUser = $('#ImgUser').data('name');

    switch (ImgUser) {
        case "Knight":
            var aranaktu = document.getElementById('2');
            aranaktu.src = "../Images/Knight_Placeholder.png";
            break;
        case "Paladin":
            var aranaktu = document.getElementById('2');
            aranaktu.src = "../Images/Paladin_Placeholder.png";
            break;
        case "Huntress":
            var aranaktu = document.getElementById('2');
            aranaktu.src = "../Images/Huntress_Placeholder.png";
            break;
        case "Valkyrie":
            var aranaktu = document.getElementById('2');
            aranaktu.src = "../Images/Valkyrie_Placeholder.png";
            break;
        case "Spooky":
            var aranaktu = document.getElementById('2');
            aranaktu.src = "../Images/Spooky_Placeholder.png";
            break;
        case "Nightmare":
            var aranaktu = document.getElementById('2');
            aranaktu.src = "../Images/Spooky2_Placeholder.png";
            break;
    }
}

function EnemyImage()
{
    ImgEnemy = $('#ImgEnemy').data('name');

    switch (ImgEnemy) {
        case "Bandit":
            var aranaktu = document.getElementById('3');
            aranaktu.src = "../Images/Enemy_Placeholder.png";
            break;
        case "Chomper":
            var aranaktu = document.getElementById('3');
            aranaktu.src = "../Images/Enemy2_Placeholder.png";
            break;
        case "Spikey":
            var aranaktu = document.getElementById('3');
            aranaktu.src = "../Images/Enemy3_Placeholder.png";
            break;
        case "Stinger":
            var aranaktu = document.getElementById('3');
            aranaktu.src = "../Images/Boss_Placeholder.png";
            break;
    }
}

function BattleImages()
{
    UserImage();
    EnemyImage();
}

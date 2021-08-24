' GameMenu will have different screens that the player can sift through.
' This is a container for the different menus that the player can view using
' hotkeys.

imports System.Collections.Generic

public class GameMenu
    private menuOrder as List(of string)
    public property currentMenu as string

    '' Constructors ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub new ()
        ' Load self from disk.
        me.menuOrder = new List(Of String) from {
            "STATS",
            "MAINWEAPON",
            "SUBWEAPON"
        }
        me.currentMenu = "STATS"
    end sub

    '' Render ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub render ()
        ' Render the current menu.
        if me.currentMenu = "STATS" then
            me.renderUserStats
        else if me.currentMenu = "MAINWEAPON" then
            me.renderUserMainWeapon
        else if me.currentMenu = "SUBWEAPON" then
            me.renderUserSubWeapon
        end if
    end sub

    function renderSeperator () as string
        return "".padRight(GAME.WMANAGER.width, "-")
    end function

    '' Menu Switching ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub nextMenu ()
        ' Find index of current menu and switch to next one.
        dim curMenuIndex as integer = me.menuOrder.indexOf(me.currentMenu)
        Game.GDEBUGGER.log(curMenuIndex.toString)
        if curMenuIndex = me.menuOrder.count - 1 then 
            me.currentMenu = me.menuOrder(0)
        else
            me.currentMenu = me.menuOrder(curMenuIndex + 1)
        end if
    end sub

    public sub previousMenu ()
        ' Find index of current menu and switch to next one.
        dim curMenuIndex as integer = me.menuOrder.indexOf(me.currentMenu)
        Game.GDEBUGGER.log(curMenuIndex.toString)
        if curMenuIndex = 0 then 
            me.currentMenu = me.menuOrder(me.menuOrder.count-1)
        else
            me.currentMenu = me.menuOrder(curMenuIndex - 1)
        end if
    end sub

    '' Menus Available '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    public sub renderUserStats ()
        ' Render user stats menu.
        dim title as string = "User Stats"
        console.writeLine(title)
        console.writeLine(me.renderSeperator)
        console.writeLine("HP: " & GAME.USER.hp)
        console.writeLine("Attack: " & GAME.USER.attack)
        console.writeLine("Speed: " & GAME.USER.speed)
    end sub

    public sub renderUserMainWeapon ()
        ' Show stats of users weapons.
        dim title as string = "Main Weapon"
        console.writeLine(title)
        console.writeLine(me.renderSeperator)
        console.writeLine("Name: " & GAME.USER.weaponMain.toString)
        console.writeLine("Damage: 0" )
    end sub

    public sub renderUserSubWeapon ()
        ' Show stats of users weapons.
        dim title as string = "Sub Weapon"
        console.writeLine(title)
        console.writeLine(me.renderSeperator)
        console.writeLine("Name: " & GAME.USER.weaponSub.toString)
        console.writeLine("Damage: 0" )
    end sub
end class
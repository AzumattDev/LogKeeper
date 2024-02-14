# LogKeeper

LogKeeper is a utility mod for BepInEx that enhances game logging capabilities. It automatically backs up log files,
appending a timestamp to each, and maintains a clean log history by keeping only a specified number of recent logs (
Default 5). This
mod is essential for developers and users who need to debug issues, or keep a historical
record of game logs. We all know that one person who boots their game after reporting a bug, and then the logs are gone
from when the bug occurred. This mod is for them.

`This mod can be independently installed on either the client or the server, based on your log management needs. Please note, installing it on the server will only manage server logs, and similarly, installing it on the client will only manage client logs. It does not synchronize or manage logs across both; installation must be on the specific side where log backups are desired.`

`This mod uses a file watcher. If the configuration file is not changed with BepInEx Configuration Manager but changed in the file, upon file save, it will update your setting internally.`


---

### Log File Location

After installation, LogKeeper will automatically manage log files located in the `LogKeeperLogs` directory within the
BepInEx folder. Here's how to locate this directory:

- **On the Client**: `BepInEx/LogKeeperLogs`
    - **For manual installations:** Directly drag and drop the log file into Discord. Access your BepInEx folder by
      going to Steam, right-clicking on Valheim, selecting `Manage > Browse local files`, and navigating to
      the `BepInEx` folder.
    - **Using r2modman or Thunderstore Mod Manager?** Access your logs by navigating
      through `Settings > Browse profile folder`, then proceed to the `BepInEx` folder.
- **On the Server**: `BepInEx/LogKeeperLogs` in the server's installation directory.

This directory will contain backups of your log files, with each backup timestamped for easy identification and
management. (e.g., `LogOutput_2024-02-14_05-48-08.log`) which is in the format `LogOutput_yyyy-MM-dd_HH-mm-ss.log`.


<details>
<summary><b>Installation Instructions</b></summary>

***You must have BepInEx installed correctly! I can not stress this enough.***

### Manual Installation

`Note: (Manual installation is likely how you have to do this on a server, make sure BepInEx is installed on the server correctly)`

1. **Download the latest release of BepInEx.**
2. **Extract the contents of the zip file to your game's root folder.**
3. **Download the latest release of from Thunderstore.io.**
4. **Extract the contents of the zip file to the `BepInEx/plugins` folder.**
5. **Launch the game.**

### Installation through r2modman or Thunderstore Mod Manager

1. **Install [r2modman](https://valheim.thunderstore.io/package/ebkr/r2modman/)
   or [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager).**

   > For r2modman, you can also install it through the Thunderstore site.
   ![](https://i.imgur.com/s4X4rEs.png "r2modman Download")

   > For Thunderstore Mod Manager, you can also install it through the Overwolf app store
   ![](https://i.imgur.com/HQLZFp4.png "Thunderstore Mod Manager Download")
2. **Open the Mod Manager and search for "" under the Online
   tab. `Note: You can also search for "Azumatt" to find all my mods.`**

   `The image below shows VikingShip as an example, but it was easier to reuse the image.`

   ![](https://i.imgur.com/5CR5XKu.png)

3. **Click the Download button to install the mod.**
4. **Launch the game.**

</details>

<br>
<br>

`Feel free to reach out to me on discord if you need manual download assistance.`

# Author Information

### Azumatt

`DISCORD:` Azumatt#2625

`STEAM:` https://steamcommunity.com/id/azumatt/

For Questions or Comments, find me in the Odin Plus Team Discord or in mine:

[![https://i.imgur.com/XXP6HCU.png](https://i.imgur.com/XXP6HCU.png)](https://discord.gg/qhr2dWNEYq)
<a href="https://discord.gg/pdHgy6Bsng"><img src="https://i.imgur.com/Xlcbmm9.png" href="https://discord.gg/pdHgy6Bsng" width="175" height="175"></a>
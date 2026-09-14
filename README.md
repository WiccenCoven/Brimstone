<img width="1600" height="1067" alt="VicceColorless" src="https://github.com/user-attachments/assets/592c6d1a-39de-4daf-9dfb-bb5c09cc4c23" />

Brimstone is a fork of Monolith which is a fork of Frontier that runs on the [Robust Toolbox](https://github.com/space-wizards/RobustToolbox) engine written in C#.

It is designed around a "ground up" philosophy.

This is the "development" fork, featuring the core necessities that make Wicce's Brimstone. It may or may not lack certain "secret" content, such as chemical recipes and visual assets.  

## Links
Repository: [Brimstone](https://github.com/WiccenCoven/Brimstone)
Repository: [Monolith](https://github.com/Monolith-Station/Monolith)
Repository: [Frontier Station 14](https://github.com/new-frontiers-14/frontier-station-14)

Discord: [Wicce](https://discord.gg/XH7hk5TS74)

## Contributing

While we are happy to accept assistance from anybody of any skill level, since Brimstone is designed "ground up" compared to other forks who inherit (lore, content, mechanics, etc) and just run with what they have, you may find your vision conflicting with ours. Please get in contact with Jaeger herself or a maintainer before pitching an idea. We would hate for you to spend a lot of time making a feature that we simply don't want.

## Building

Refer to [the Space Wizards' guide](https://docs.spacestation14.com/en/general-development/setup/setting-up-a-development-environment.html) on setting up a development environment for general information, but keep in mind that Einstein Engines is not the same and many things may not apply.
We provide some scripts shown below to make the job easier.

### Build dependencies

> - Git
> - .NET SDK 10.0

### Windows

> 1. Clone this repository
> 2. Run `Scripts/bat/updateEngine.bat` in a terminal or in file explorer to download the engine
> 3. Run `Scripts/bat/buildAllDebug.bat` after making any changes to the source
> 4. Run `Scripts/bat/runQuickAll.bat` to launch the client and the server
> 5. Connect to localhost in the client and play

### Linux

> 1. Clone this repository
> 2. Run `Scripts/sh/updateEngine.sh` in a terminal to download the engine
> 3. Run `Scripts/sh/buildAllDebug.sh` after making any changes to the source
> 4. Run `Scripts/sh/runQuickAll.sh` to launch the client and the server
> 5. Connect to localhost in the client and play

### MacOS

> 1. Clone this repository
> 2. Run `Scripts/sh/updateEngine.sh` in a terminal to download the engine
> 3. Run `Scripts/sh/buildAllDebug.sh` after making any changes to the source
> 4. Run `Scripts/sh/runQuickAll.sh` to launch the client and the server
> 5. Connect to localhost in the client and play

## License

IMPORTANT: Some Wicce code and assets are licensed under ALL RIGHTS RESERVED, and may or may not be in this repository. Such items are clearly marked in their respective `meta.json` or at the top of the file. 

See the REUSE headers for detailed licensing information for each file for the specific licenses contributions are made under. The work as a whole is licensed under GNU Affero General Public License version 3.0.

By default, original code contributed to the Monolith codebase after 04d8ce483f638320d1b85a7aaacdf01442757363 is under Mozilla Public License version 2.0 with Exhibit B removed. See `LICENSE-MPL.txt`.

Content contributed to this repository after commit 2fca06eaba205ae6fe3aceb8ae2a0594f0effee0 is licensed under the GNU Affero General Public License version 3.0, unless otherwise stated. See `LICENSE-AGPLv3.txt`.

Content contributed to this repository before commit 2fca06eaba205ae6fe3aceb8ae2a0594f0effee0 is licensed under the MIT license, unless otherwise stated. See `LICENSE-MIT.txt`.

[2fca06eaba205ae6fe3aceb8ae2a0594f0effee0](https://github.com/new-frontiers-14/frontier-station-14/commit/2fca06eaba205ae6fe3aceb8ae2a0594f0effee0) was pushed on July 1, 2024 at 16:04 UTC

Most assets are licensed under [CC-BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/) unless stated otherwise. Assets have their license and the copyright in the metadata file. [Example](https://github.com/space-wizards/space-station-14/blob/master/Resources/Textures/Objects/Tools/crowbar.rsi/meta.json).

Note that some assets are licensed under the non-commercial [CC-BY-NC-SA 3.0](https://creativecommons.org/licenses/by-nc-sa/3.0/) or similar non-commercial licenses and will need to be removed if you wish to use this project commercially.

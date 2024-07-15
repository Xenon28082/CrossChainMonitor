Console app that monitoring cross-chain swaps between the Ethereum and Base blockchains via the Across bridge in both directions.
Lastest compiled .exe you can find [here](https://github.com/Xenon28082/CrossChainMonitor/releases/tag/release).
config.json file let you to configurate application work process.
Configuration file contains information about chains that program would try to monitor,
Each Chain object must contain information about :
1) It's name;
2) URL of chain node;
3) StartBlockNumber, from which processing will begin;
4) Duration, for how many blocks chain whould be examined;
5) UpdateFrquency, new blocks request period in milliseconds (for monitoring in real time);
6) Observers - array of observers, that whould track necessary cross-chain swap events.

For tracking in real time StartBlockNumber must be set to -1
Both config.json and .exe files must be located in the same folder.

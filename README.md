# reconnect-to-internet
A program that automatically disconnects and reconnects to a Wi-Fi network if you lose internet connection.

This was created to solve the issue I was having with my computer where I would lose internet connection, but as soon as I reconnected to the network, my internet connection would be restored. This program just automates this process.

# Usage
To use the program and have it start automatically, first modify `program.cs` and change line 54 to be your network's SSID instead of the placeholder.

After this, build the project and create a shortcut for it.

Then open `Win+R` and type `shell:common startup` and press enter.

Place the shortcut in this folder, and now when you restart your computer, the program will launch from startup.

# Credits
I made use of the [SimpleWiFi library](https://github.com/DigiExam/simplewifi) and sample code by GitHub user [DigiExam](https://github.com/DigiExam).

All other code is my own.

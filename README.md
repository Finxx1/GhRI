# GhRI
A tool to automatically fetch binaries from a git repo
### Installation
You can try to build binaries yourself, but the solution was generated on a macOS machine, so it may not work. I would just get binaries from the releases once i publish them. Just put the binaries in a global directory. I personally put my binaries in `/usr/local/bin/` on macOS/Linux/BSD and `C:\Windows\System32\` on Windows.
### Usage
> $ GhRI $(User) $(Repo)

This command will get binaries for the repository at `https://github.com/$(User)/$(Repo)`

### Plans
Hopefully, I can make it so that the tool will be able to compile binaries by itself, but right now that is just a dream.
### Why the part about `Am I a slave?`
Github API's have a rate limit, so to prevent hitting that rate limit, 1/5 times you run the program, it will ask `"What am I, a slave or something????"`. This is an attempt to slow down the user and hopefully not hit the rate limit

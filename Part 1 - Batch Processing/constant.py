# @Author: schwarze_falke
# @Date:   2019-01-30T12:47:17-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-05T02:33:13-06:00

import sys

platforms = {
    'linux' : 'Linux',
    'linux1' : 'Linux',
    'linux2' : 'Linux',
    'darwin' : 'OS X',
    'win32' : 'Windows'
}
if sys.platform not in platforms:
    print(sys.platform)

if platforms[sys.platform] == 'Linux':
    CLEAR = 'clear'
elif platforms[sys.platform] == 'Windows':
    CLEAR = 'cls'

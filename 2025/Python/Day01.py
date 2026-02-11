import re
import common


lines = common.open_and_read_lines_from_file('Day01.txt')
# print(lines)

regex = r"^(?P<direction>[LR])(?P<distance>\d+)$"

def parse_line(line:str) -> tuple[str,int]:
    '''
    Parses a line to determine direction and distance for dial movement.
    
    :param line: The input line to be parsed format of direction 'L' or 'R' followed by a postitive whole number to indicated distance.

    Returns:
        Returns a tuple of (direction, distance)
    '''
    matches = re.match(regex, line)

    return matches.group('direction'), int(matches.group('distance'))

position = 50 # This is our starting position
times_at_zero = 0

for line in lines:
    direction, distance = parse_line(line)

    # Moving left
    if direction == 'L':
        position -= distance % 100
        if position < 0:
            position += 100

    if direction == 'R':
        position += distance % 100
        if position > 99:
            position -= 100

    if position == 0:
        times_at_zero += 1

print(f'Day 01 - Part 1: {times_at_zero}')
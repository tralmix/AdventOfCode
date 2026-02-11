from pathlib import Path
def open_and_read_lines_from_file(file_name):
    current_dir = Path(__file__).resolve().parent
    file_path = current_dir / '..' / 'Inputs' / file_name
    file_path = file_path.resolve()
    input_file = open(file_path, "r")
    lines = input_file.readlines()
    return lines
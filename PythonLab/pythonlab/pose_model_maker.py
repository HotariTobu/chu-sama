from pathlib import Path
import numpy as np

from sklearn.model_selection import train_test_split

import tensorflow as tf
from tensorflow import keras

def loadnp(path: Path):


def main():
    data_path = Path('data/pose')
    pose_file_paths = list(data_path.glob('*.dat'))

    data = []
    with open(args.input_path, "r") as f:
        for line in f:
            coordinates = []
            for coord_str in line.strip().split():
                x, y, z = map(float, coord_str.split(","))
                coordinates.append([x, y, z])
            data.append(coordinates)

    matrix = np.array(data)
    matrix
    print(matrix)
    print(matrix.shape)  # 行列の次元を表示

if __name__ == "__main__":
    main()

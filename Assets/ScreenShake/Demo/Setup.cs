/*
 * Copyright © 2015 Rustic 
 * This file is part of the Rustic Unity Toolset.
 *
 * The Rustic Unity Toolset is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * The Rustic Unity Toolset is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with The Rustic Unity Toolset.  If not, see <http://www.gnu.org/licenses/>.
 */

using UnityEngine;

public class Setup : MonoBehaviour
{
  public UnityEngine.UI.Button button;

  void Start () {
    button.onClick.AddListener(() => {
	var cam = Camera.main;
	var x = Random.Range(0.1f, 0.8f);
	var y = Random.Range(0.1f, 0.8f);
	var duration = Random.Range(0.8f, 1.2f);
	var frequency = Random.Range(0.05f, 0.15f);
	StartCoroutine(Rustic.ScreenShake.Shake(cam, x, y, duration, frequency));
      });
  }
}

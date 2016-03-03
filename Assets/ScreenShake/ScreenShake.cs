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
using System.Collections;

namespace Rustic {
  public static class ScreenShake {
    public static IEnumerator Shake(Camera cam,
				    float x,
				    float y,
				    float duration,
				    float frequency) {
      var time = 0f;
      var initialCamPos = cam.transform.position;

      while(time <= duration) {
	time += Time.deltaTime + frequency;

	var xPos = Random.Range(-x, x);
	var yPos = Random.Range(-y, y);
	var zPos = cam.transform.position.z;
	cam.transform.position = new Vector3(xPos, yPos, zPos);

	yield return new WaitForSeconds(frequency);
      }

      cam.transform.position = initialCamPos;
    }
  }
}

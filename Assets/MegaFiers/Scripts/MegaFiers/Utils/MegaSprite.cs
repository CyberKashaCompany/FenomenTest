﻿using UnityEngine;

// ffd for 2d sprites, if check2d then all points match front set
namespace MegaFiers
{
	[ExecuteInEditMode]
	public class MegaSprite : MonoBehaviour
	{
		[Range(1, 32)]
		public int				subDivLevel		= 4;
		public Shader			shader;
		public string			texname			= "_MainTex";
		[HideInInspector]
		public bool				build			= false;
		public float			minDeformLevel	= 0.0001f;
		[HideInInspector]
		public SpriteRenderer	spriteRenderer;
		[HideInInspector]
		public MeshRenderer		meshRenderer;
		[HideInInspector]
		public GameObject		spriteMeshObj;
		[HideInInspector]
		public MegaModifyObject	modObj;
		public Vector3			pivot;

		void Start()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		void Update()
		{
			if ( spriteRenderer )
			{
				if ( build )
				{
					UpdateSprite();
					build = false;
				}

				if ( modObj && meshRenderer )
				{
					bool anyDeform = modObj.AnyDeform(minDeformLevel);
					if ( anyDeform )
					{
						spriteRenderer.enabled	= false;
						meshRenderer.enabled	= true;
					}
					else
					{
						spriteRenderer.enabled	= true;
						meshRenderer.enabled	= false;
					}
				}
			}
		}

		public void UpdateSprite()
		{
			Shader newshader = spriteRenderer.sharedMaterial.shader;
			if ( shader )
				newshader = shader;

			if ( spriteMeshObj )
			{
				MegaSpriteToMesh.UpdateMesh(spriteMeshObj, gameObject, subDivLevel, pivot);
			}
			else
			{
				spriteMeshObj = MegaSpriteToMesh.CreateMeshObjectFromSprite(gameObject, subDivLevel, pivot, newshader);

				if ( spriteMeshObj )
				{
					modObj = spriteMeshObj.AddComponent<MegaModifyObject>();
					modObj.NormalMethod = MegaNormalMethod.None;
					modObj.TangentMethod = MegaTangentMethod.None;
					modObj.InvisibleUpdate = true;
					meshRenderer = modObj.GetComponent<MeshRenderer>();
				}
			}
		}
	}
}